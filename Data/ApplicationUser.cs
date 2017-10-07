using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WeTube.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class MyRole : IdentityRole<int>
    {
        public MyRole() : base()
        {
        }

        public MyRole(string roleName)
        {
            Name = roleName;
        }
    }
}
