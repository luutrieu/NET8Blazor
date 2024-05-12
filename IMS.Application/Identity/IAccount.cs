using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.ActivityTracker;
using IMS.Application.DTO.Response.Identity;
using IMS.Application.DTO.Resquest.ActivityTracker;
using IMS.Application.DTO.Resquest.Identity;

namespace IMS.Application.Identity
{
    public interface IAccount
    {
        Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model);
        Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model);
        Task<IEnumerable<GetUserWithClaimResponseDTO>> GetUsersWithClaimsAsync();
        Task SetUpAsync();
        Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model);
        Task SaveActivityAsync(ActivityTrackerRequestDTO model);
        Task<IEnumerable<ActivityTrackerResponseDTO>> GetActivitiesAsync();
    }
}
