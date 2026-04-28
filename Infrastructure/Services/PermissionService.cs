

using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User
            ?? new ClaimsPrincipal(new ClaimsIdentity());

        public string UserId()
        {
            var sub = User.FindFirst("sub")?.Value;
            if (!string.IsNullOrWhiteSpace(sub)) return sub;
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        public string? UserName() => User.FindFirst("preferred_username")?.Value;

        public string? Email() => User.FindFirst(ClaimTypes.Email)?.Value;
    }
}
