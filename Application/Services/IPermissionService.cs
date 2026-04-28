

namespace Application.Services
{
    public interface IPermissionService
    {
        string UserId();
        string? UserName();
        string? Email();
    }
}
