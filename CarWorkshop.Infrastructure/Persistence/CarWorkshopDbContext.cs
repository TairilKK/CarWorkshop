using CarWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDbContext : IdentityDbContext
    {
        public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }

        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarWorkshop>()
               .OwnsOne(c => c.ContactDetails);
                
        }
    }
}
