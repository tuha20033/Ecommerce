

using Application.DTOs;

namespace Application.Services
{
    public interface IKeycloakUserService
    {
        Task <IReadOnlyList<KeyCloakUserDTO>> SearchShare ( string keyword , int max =  10, CancellationToken cancellationToken = default);
        Task<KeyCloakUserDTO?> GetUserById(string id, CancellationToken cancellation);
    }
}
