using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace Indentity.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // EW: Get Environment Database
        private static string _connection = Auxilary.Helpers.EnvironmentConnection;

        public ApplicationDbContext()
            : base(_connection, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }







        /*
         * EW - Adding a new model/table to EntityFramework - DbSet<>
         */
        public DbSet<Books> Books { get; set; }
    }
    /*
     * EW - Adding a new model/table to EntityFramework - Class 
     */
    public class Books
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string GoobldyGook { get; set; }
    }








    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavouriteFood { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}