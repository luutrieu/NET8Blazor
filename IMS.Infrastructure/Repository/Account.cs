using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.ActivityTracker;
using IMS.Application.DTO.Response.Identity;
using IMS.Application.DTO.Resquest.ActivityTracker;
using IMS.Application.DTO.Resquest.Identity;
using IMS.Application.Extension.Identity;
using IMS.Application.Identity;
using IMS.Domain.Entites.ActivityTracker;
using IMS.Infrastructure.DataAccess;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;

namespace IMS.Infrastructure.Repository
{
    public class Account
        (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context) : IAccount
    {
        public async Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model)
        {
            var user = await FindUserByEmail(model.Email);
            if (user != null)
                return new ServiceResponse(false, "User already exist");

            var newUser = new ApplicationUser()
            {
                UserName = model.Email,
                PasswordHash = model.Password,
                Email = model.Email,
                Name = model.Name
            };

            var result = CheckResult(await userManager.CreateAsync(newUser, model.Password));
            if (!result.Flag)
                return result;
            else
                return await CreateUserClaims(model);
        }

        private async Task<ServiceResponse> CreateUserClaims(CreateUserRequestDTO moddel)
        {
            if (string.IsNullOrEmpty(moddel.Policy)) return new ServiceResponse(false, "No policy specified");
            Claim[] userclaim = [];
            if (moddel.Policy.Equals(Policy.AdminPolicy, StringComparison.OrdinalIgnoreCase))
            {
                userclaim = [
                    new Claim(ClaimTypes.Email, moddel.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("Name", moddel.Name),
                    new Claim("Create","true"),
                    new Claim("Update","true"),
                    new Claim("Delete","true"),
                    new Claim("Read","true"),
                    new Claim("Manager","true")
                    ];
            }
            else if (moddel.Policy.Equals(Policy.ManagerPolicy, StringComparison.OrdinalIgnoreCase))
            {
                userclaim = [
                     new Claim(ClaimTypes.Email, moddel.Email),
                    new Claim(ClaimTypes.Role, "Manager"),
                    new Claim("Name", moddel.Name),
                    new Claim("Create","true"),
                    new Claim("Update","true"),
                    new Claim("Delete","true"),
                    new Claim("Read","true"),
                    new Claim("Manager","false")
                    ];
            }
            else if (moddel.Policy.Equals(Policy.UserPolicy, StringComparison.OrdinalIgnoreCase))
            {
                userclaim = [
                    new Claim(ClaimTypes.Email, moddel.Email),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim("Name", moddel.Name),
                    new Claim("Create","true"),
                    new Claim("Update","true"),
                    new Claim("Delete","true"),
                    new Claim("Read","true"),
                    new Claim("Manager","false")
                   ];
            }

            var result = CheckResult(await userManager.AddClaimsAsync((await FindUserByEmail(moddel.Email)), userclaim));
            if (result.Flag)
                return new ServiceResponse(true, "User created");
            else
                return result;
        }
        public async Task<IEnumerable<GetUserWithClaimResponseDTO>> GetUsersWithClaimsAsync()
        {
            var userList = new List<GetUserWithClaimResponseDTO>();
            var allUser = await userManager.Users.ToListAsync();
            if (allUser.Count == 0) return userList;

            foreach (var user in allUser)
            {
                var currentUser = await userManager.FindByIdAsync(user.Id);
                var getCurrentUserClaims = await userManager.GetClaimsAsync(currentUser);
                if (getCurrentUserClaims.Any())
                    userList.Add(new GetUserWithClaimResponseDTO()
                    {
                        UserId = user.Id,
                        Email = getCurrentUserClaims.FirstOrDefault(_ => _.Type == ClaimTypes.Email).Value,
                        RoleName = getCurrentUserClaims.FirstOrDefault(_ => _.Type == ClaimTypes.Role).Value,
                        Name = getCurrentUserClaims.FirstOrDefault(_ => _.Type == "Name").Value,
                        ManagerUser = Convert.ToBoolean(getCurrentUserClaims.FirstOrDefault(_ => _.Type=="ManagerUser").Value),
                        Create = Convert.ToBoolean(getCurrentUserClaims.FirstOrDefault(_ => _.Type =="Create").Value),
                        Update = Convert.ToBoolean(getCurrentUserClaims.FirstOrDefault(_ => _.Type=="Update").Value),
                        Delete = Convert.ToBoolean(getCurrentUserClaims.FirstOrDefault(_ => _.Type=="Delete").Value),
                        Read = Convert.ToBoolean(getCurrentUserClaims.FirstOrDefault(_ => _.Type=="Read").Value)

                    });
            }
            return userList;
        }

        public async Task SetUpAsync() => await CreateUserAsync(new CreateUserRequestDTO
        {
            Name="Administrator",
            Email="admin@admin.com",
            Password="Admin@123",
            Policy=Policy.AdminPolicy
        });
        public async Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model)
        {
            var user = await FindUserByEmail(model.Email);
            if (user is null) return new ServiceResponse(false, "User not found");

            var verifyPassword = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!verifyPassword.Succeeded) return new ServiceResponse(false, "Incorrect credential provided");

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
                return new ServiceResponse(false, "Unknown error occured while logging you in");
            else
                return new ServiceResponse(true, null);
        }

        private async Task<ApplicationUser> FindUserByEmail(string email)
            => await userManager.FindByEmailAsync(email);

        private async Task<ApplicationUser> FindUserById(string id) =>await userManager.FindByIdAsync(id);
        public async Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user == null) return new ServiceResponse(false, "User not found");

            var oldUserClaims = await userManager.GetClaimsAsync(user);
            Claim[] newUserClaims = [
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, model.RoleName),
                new Claim("Name",model.Name),
                new Claim("Create", model.Create.ToString()),
                new Claim("Update", model.Update.ToString()),
                new Claim("Read", model.Read.ToString()),
                new Claim("Manager", model.ManagerUser.ToString()),
                new Claim("Delete", model.Delete.ToString()),
                ];

            var result = await userManager.RemoveClaimsAsync(user, oldUserClaims);
            var response = CheckResult(result);
            if (!response.Flag)
                return new ServiceResponse(false, response.Message);

            var addNewClaims = await userManager.AddClaimsAsync(user, newUserClaims);
            var outcome = CheckResult(addNewClaims);
            if (outcome.Flag)
                return new ServiceResponse(true, "User updated");
            else
                return outcome;
        }

        private static ServiceResponse CheckResult(IdentityResult identityResult)
        {
            if (identityResult.Succeeded) return new ServiceResponse(true, null);

            var error = identityResult.Errors.Select(_ => _.Description);
            return new ServiceResponse(false, string.Join(Environment.NewLine, error));
        }

        public async Task SaveActivityAsync(ActivityTrackerRequestDTO model)
        {
            context.ActivityTracker.Add(model.Adapt(new Tracker()));
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActivityTrackerResponseDTO>> GetActivitiesAsync()
        {
           var list = new List<ActivityTrackerResponseDTO>();
            var data = (await context.ActivityTracker.ToListAsync()).Adapt <List<ActivityTrackerResponseDTO>>();
            foreach ( var activity in data)
            {
                activity.UserName = (await FindUserById(activity.UserId)).Name;
                list.Add(activity);
            }
            return data;
        }

    }
}
