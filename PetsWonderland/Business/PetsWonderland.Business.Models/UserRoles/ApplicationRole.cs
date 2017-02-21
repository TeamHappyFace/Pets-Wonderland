using Microsoft.AspNet.Identity.EntityFramework;

namespace PetsWonderland.Business.Models.UserRoles
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string name) : base(name)
        {
        }

        public string Description { get; set; }
    }
}
