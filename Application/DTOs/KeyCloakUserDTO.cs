

namespace Application.DTOs
{
    public class KeyCloakUserDTO(string Id,
    string Username,
    string? Email,
    string? FirstName,
    string? LastName)
    {
        public string Id { get; } = Id;
        public string Username { get; } = Username;
        public string? Email { get; } = Email;
        public string? FirstName { get; } = FirstName;
        public string? LastName { get; } = LastName;

        public string DisplayName =>
    string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName)
        ? Username
        : $"{FirstName} {LastName}".Trim();
    }
}
