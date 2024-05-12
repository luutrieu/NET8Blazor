using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.ActivityTracker;
using IMS.Application.DTO.Response.Identity;
using IMS.Application.DTO.Resquest.ActivityTracker;
using IMS.Application.DTO.Resquest.Identity;
using IMS.Application.Identity;

namespace IMS.Application.Service.Identity
{
    public class AccountService(IAccount account) : IAccountService
    {
        public async Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model)
            => await account.CreateUserAsync(model);

        public async Task<IEnumerable<ActivityTrackerResponseDTO>> GetActivitiesAsync()
            => await account.GetActivitiesAsync();

        public async Task<IEnumerable<IGrouping<DateTime, ActivityTrackerResponseDTO>>> GroupActivities()
            {
            var data = (await GetActivitiesAsync()).GroupBy(e=>e.Date).AsEnumerable();
            return data;
            }
        public async Task<IEnumerable<GetUserWithClaimResponseDTO>> GetUsersWithClaimsAsync()
             => await account.GetUsersWithClaimsAsync();

        public Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model)
            => account.LoginAsync(model);

        public async Task SaveActivityAsync(ActivityTrackerRequestDTO model)
       => account.SaveActivityAsync(model);

        public async Task SetUpAsync() =>await account.SetUpAsync();
        

        public async Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model)
            => await account.UpdateUserAsync(model);
    }
}
