namespace Indentity.Migrations
{
    using Indentity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Indentity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Indentity.Models.ApplicationDbContext";
        }

        protected override void Seed(Indentity.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "errol@bubbanoosh.com.au"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                //UseManager will HASH the password
                var user = new ApplicationUser { UserName = "errol@bubbanoosh.com.au" };
                manager.Create(user, "password");
                user = new ApplicationUser { UserName = "e@bubbanoosh.com.au" };
                manager.Create(user, "newpassword");
            }



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
