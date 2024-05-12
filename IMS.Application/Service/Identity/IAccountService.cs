using IMS.Application.DTO.Response.Identity;
using IMS.Application.DTO.Response;
using IMS.Application.DTO.Resquest.Identity;
using IMS.Application.DTO.Response.ActivityTracker;
using IMS.Application.DTO.Resquest.ActivityTracker;

namespace IMS.Application.Service.Identity
{
    public interface IAccountService
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
