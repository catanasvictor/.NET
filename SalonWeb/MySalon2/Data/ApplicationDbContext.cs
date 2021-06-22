using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalonWeb.DomainModel;

namespace SalonWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        //public DbSet<User> User { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Task> Task { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
