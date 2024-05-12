using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Extension.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
