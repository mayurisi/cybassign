namespace ModelDemo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ModelDemo.Models.ApplicationDbContext";
        }

        protected override void Seed(ModelDemo.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                //creating user with password
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin" };
                manager.Create(user, "password");

                //creating role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "admin" });
                //adding above user to the role
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
