using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.IdentityEntities;
using System.Reflection;
using System.Linq;

namespace Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<country> Countries { get; set; }
        public DbSet<currency> Currencies { get; set; }
        public DbSet<language> Languages { get; set; }
        public DbSet<promo_codes> Promo_Codes { get; set; }
        public DbSet<property_amenities> Property_Amenities { get; set; }
        public DbSet<property_images> Property_Images { get; set; }
        public DbSet<property_reviews> Property_Reviews { get; set; }
        public DbSet<property_tybe> Property_Tybes { get; set; }
        public DbSet<property> Properties { get; set; }
        public DbSet<state> States { get; set; }
        public DbSet<transaction> Transactions { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        public DbSet<ApplicationRole> applicationRoles { get; set; }
        public  DbSet<ApplicationUserRole> applicationUserRoles { get; set; }
        public  DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach(var foreignkey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}