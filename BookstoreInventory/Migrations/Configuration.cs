namespace BookstoreInventory.Migrations
{
    using BookstoreInventory.Identity;
    using BookstoreInventory.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<BookstoreInventory.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookstoreInventory.Models.ApplicationDbContext context)
        {
            context.Books.AddOrUpdate(
         b => b.Title,
         new Book { Title = "Sample Book", Author = "Sample Author", Genre = "Sample Genre", Price = 19.99M, PublicationDate = DateTime.Now }
     );
            context.Users.AddOrUpdate(
                    u => u.Username,
                    new User { Username = "admin", PasswordHash = "adminhash", Role = "admin" },
                    new User { Username = "user", PasswordHash = "userhash", Role = "user" }
                );

        

       
                // Seed Roles
                var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }
                if (!roleManager.RoleExists("User"))
                {
                    roleManager.Create(new IdentityRole("User"));
                }

                // Seed Users
                var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var adminUser = userManager.FindByName("admin@example.com");
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com" };
                    userManager.Create(adminUser, "Password123!");
                    userManager.AddToRole(adminUser.Id, "Admin");
                }

                var regularUser = userManager.FindByName("user@example.com");
                if (regularUser == null)
                {
                    regularUser = new ApplicationUser { UserName = "user@example.com", Email = "user@example.com" };
                    userManager.Create(regularUser, "Password123!");
                    userManager.AddToRole(regularUser.Id, "User");
                }
            }
        }


    }


