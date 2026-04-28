

using Application.DTOs;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
namespace Infrastructure.Services
{
    public class KeyCloakUserService : IKeycloakUserService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<KeyCloakUserService> logger;
        //Authority,  Realm, AdminClientId những  thằng này là để đọc cấu hình từ appsettings.json

        private string Authority => configuration["Keycloak:Authority"] ?? throw new InvalidOperationException("Keycloak:Authority missing");
        private string Realm => configuration["Keycloak:Realm"] ?? throw new InvalidOperationException("Keycloak:Realm missing");
        private string AdminClientId => configuration["Keycloak:AdminClientId"] ?? "admin-cli";
        private string AdminSecret => configuration["Keycloak:AdminClientSecret"] ?? throw new InvalidOperationException("Keycloak:AdminClientSecret missing");

        // thằng BaseUrl  và thằng Authori dùng 2 url khác nhau ,
        // thằng dùng để xác thực còn 1 thằng dùng để Gọi API admin
        private string BaseUrl => Authority.Contains("/realms/")
            ? Authority[..Authority.IndexOf("/realms/", StringComparison.Ordinal)]
            : Authority;

        public KeyCloakUserService(IHttpClientFactory httpClientFactory, IConfiguration configuration , ILogger<KeyCloakUserService> logger)
        {
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        private async Task<string> GetAdminTokenAsync(CancellationToken ct)
        {   // tạo ra 1 thằng http 
            var http = httpClientFactory.CreateClient("keycloak");
            // lưu đại chỉ xin token của thằng keycloak vào thằng tokenUrl 
            var tokenUrl = $"{BaseUrl}/realms/{Realm}/protocol/openid-connect/token";
            // body là những thông tin của 1 thằng mà mình cần xin 
            var body = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = AdminClientId,  // tên của ứng dụng như thằng webportal này chẳng hạn 
                ["client_secret"] = AdminSecret  // mật khẩu của ứng dụng 
            };

            // gửi đến keycloak gồng địa chỉ và thông tin 
            var response = await http.PostAsync(tokenUrl, new FormUrlEncodedContent(body), ct);
            // xem thằng keycloak có chấp nhận không
            // nếu bận đi xem phim chs bời thì sẽ lỗi 
            response.EnsureSuccessStatusCode();
            // trả về dạng json 
            var json = await response.Content.ReadAsStringAsync(ct);
            // chuyển sang object
            var result = JsonSerializer.Deserialize<JsonElement>(json);
            // sau đó trả về hết 
            return result.GetProperty("access_token").GetString()
                   ?? throw new InvalidOperationException("Keycloak token response missing access_token");
        }

        public async Task<KeyCloakUserDTO?> GetUserById(string id, CancellationToken cancellation)
        {
            try
            {
                var token = await GetAdminTokenAsync(cancellation);

                var http = httpClientFactory.CreateClient("keycloak");

                var url = $"{BaseUrl}/admin/realms/{Realm}/users/{id}";
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await http.GetAsync(url, cancellation);
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync(cancellation);
                var u = JsonSerializer.Deserialize<KeycloakUserJson>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (u is null) return null;
                return new KeyCloakUserDTO(u.Id ?? "", u.Username ?? "", u.Email, u.FirstName, u.LastName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Keycloak get user by id failed: {UserId}", id);
                return null;
            }
        }

        public async Task<IReadOnlyList<KeyCloakUserDTO>> SearchShare(string keyword, int max = 10, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return Array.Empty<KeyCloakUserDTO>();

            try
            {
                // thằng token này là gọi đến hàm GetAdminTokenAsync để lấy token
                var token = await GetAdminTokenAsync(cancellationToken);

                // http
                var http = httpClientFactory.CreateClient("keycloak");

                // tạo ra một url để gọi API admin của Keycloak để tìm kiếm người dùng dựa trên keyword
                var url = $"{BaseUrl}/admin/realms/{Realm}/users?search={Uri.EscapeDataString(keyword)}&max={max}";
                // thằng này EscapeDataString nó sẽ dịch từ khóa tìm kiếm sang url
                // ví dụ" hà ngọc tú " sẽ được dịch thành "h%C3%A0%20ng%E1%BB%8Dc%20t%C3%BA"
                // để đảm bảo url hợp lệ


                // đính token của hệ thống vào header
                // để Keycloak biết đây là request hợp lệ, có quyền gọi Admin API
                // khi đi em hỏi khi về em chào 
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // gửi yêu cầu sau đó hút thuốc ngồi chơi xơi nước 
                var response = await http.GetAsync(url, cancellationToken);

                response.EnsureSuccessStatusCode();// kiểm tra xem có lỗi không 

                var json = await response.Content.ReadAsStringAsync(cancellationToken);
                // đoạn này thằng  keycloak trả về kiểu json 
                var users = JsonSerializer.Deserialize<List<KeycloakUserJson>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                // Phải từ Json sang kiểu Object để có thể truy cập đến từng thằng một 

                return users? // nếu thằng user này null thì thôi 
                    .Select(u => new KeyCloakUserDTO(
                    u.Id ?? "", // nếu thằng id này null thì thôi
                    u.Username ?? "", // nếu thằng Username này null thì thôi
                    u.Email,
                    u.FirstName,
                    u.LastName)).ToList()
                    ?? new List<KeyCloakUserDTO>(); // nếu null hết thì thôi trả về rỗng hết chối tỷ 
            }
            // Sau đó sẽ lọc những thằng cần thiết thôi
            catch (Exception ex)
            {
                logger.LogError(ex, "Keycloak search users failed for keyword: {Keyword}", keyword);
                return Array.Empty<KeyCloakUserDTO>();

                // ghi lỗi ra log 
            }
        }
        //  Lấy admin token dùng client_credentials

        private sealed class KeycloakUserJson
        {
            public string? Id { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

    }
}
