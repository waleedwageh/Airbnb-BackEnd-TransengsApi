using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Domain.IdentityEntities;

namespace Infrastructure.EntitiesConfig
{
 
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.transactions);
        }
    }
    public class CountryConfig : IEntityTypeConfiguration<country>
    {
        public void Configure(EntityTypeBuilder<country> builder)
        {
            builder.HasMany(x=>x.states).WithOne(x=>x.country).OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class TransactionConfig : IEntityTypeConfiguration<transaction>
    {


        public void Configure(EntityTypeBuilder<transaction> builder)
        {
            builder.HasOne(x => x.payee);
            builder.HasOne(x => x.Recevier);
             builder.Property(x=>x.amount)
            .HasColumnType("decimal(18,2)");
             builder.Property(x=>x.discount_amt)
            .HasColumnType("decimal(18,2)");
             builder.Property(x=>x.site_fees)
            .HasColumnType("decimal(18,2)");
        }
    }
    public class PropertyAmenitiesConfig : IEntityTypeConfiguration<property_amenities>
    {
        public void Configure(EntityTypeBuilder<property_amenities> builder)
        {
            builder.HasKey(x => new { x.amenity_id, x.property_id });

        }
    }
    public class PromoCodesConfig : IEntityTypeConfiguration<promo_codes>
    {
        public void Configure(EntityTypeBuilder<promo_codes> builder)
        {
            builder.Property(x=>x.discount)
            .HasColumnType("decimal(18,2)");
        }
    }
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(x => x.transaction).WithOne(x => x.Booking);
             builder.Property(x=>x.price_per_day)
            .HasColumnType("decimal(18,2)");
             builder.Property(x=>x.price_per_stay)
            .HasColumnType("decimal(18,2)")
            .HasComputedColumnSql("price_per_day*(DATEDIFF(day, check_in_date, check_out_date))");
             builder.Property(x=>x.tax_paid)
            .HasColumnType("decimal(18,2)")
            .HasComputedColumnSql("price_per_day*(DATEDIFF(day, check_in_date, check_out_date))*.05");
             builder.Property(x=>x.amount_paid)
            .HasColumnType("decimal(18,2)");
             builder.Property(x=>x.refund_paid)
            .HasColumnType("decimal(18,2)");
            
            
             builder.Property(x=>x.site_fees)
            .HasColumnType("decimal(18,2)")
            .HasComputedColumnSql("price_per_day*(DATEDIFF(day, check_in_date, check_out_date))*.15");
             builder.Property(x=>x.effective_amount)
            .HasColumnType("decimal(18,2)")
            .HasComputedColumnSql("price_per_day*(DATEDIFF(day, check_in_date, check_out_date))*.8");
        }
    }
    public class PropertyConfig : IEntityTypeConfiguration<property>
    {
        public void Configure(EntityTypeBuilder<property> builder)
        {

            builder.HasMany(x => x.property_reviews).WithOne(x => x.property);
            builder.Property(x=>x.price)
            .HasColumnType("decimal(18,2)");
        }
    }
}