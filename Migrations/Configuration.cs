namespace WedMarch9.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WedMarch9.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WedMarch9.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //}
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //if (!context.Users.Any(u => u.Email == "jenewby54n@yahoo.com"))
            //{
            //    userManager.Create(new ApplicationUser
            //    {
            //        UserName = "jenewby54n@yahoo.com",
            //        Email = "jenewby54n@yahoo.com",
            //        FirstName = "James",
            //        LastName = "Newby",
            //        DisplayName = "jenewby"
            //    }, "password");
            //}
            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry",
                    Email = "moderator@coderfoundry",
                    DisplayName = "Moderator"
                }, "Password-1");
            }
            //var userId = userManager.FindByEmail("jenewby54n@yahoo.com").Id;
            //userManager.AddToRole(userId, "Admin");

            var userId = userManager.FindByEmail("moderator@coderfoundry").Id;
            userManager.AddToRole(userId, "Moderator");
        }

    }
}
