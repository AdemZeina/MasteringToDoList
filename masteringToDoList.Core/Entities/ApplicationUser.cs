using Microsoft.AspNetCore.Identity;

namespace masteringToDoList.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }

        public override string UserName { get; set; }

        //public string Name { get; set; }
    }
}
