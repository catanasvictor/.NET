using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalonWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.DomainModel
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Task.Any())
                {
                    return;   // DB has been seeded
                }
                if (context.Appointment.Any())
                {
                    return;   // DB has been seeded
                }
               

               

                

               
                context.SaveChanges();
            }
        }
    }
}
