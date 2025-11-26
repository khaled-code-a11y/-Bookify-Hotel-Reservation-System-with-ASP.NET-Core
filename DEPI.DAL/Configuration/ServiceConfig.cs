

namespace DEPI.DAL.Configuration
{
    public class ServiceConfig : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.ServiceId);

            builder.Property(s => s.ServiceId).UseIdentityColumn(1, 1);

            builder.Property(s => s.ServiceType).IsRequired();
            builder.HasIndex(s => s.ServiceType).IsUnique();

            builder.Property(s => s.ServicePrice).IsRequired();

            builder.Property(s => s.Description).IsRequired().HasMaxLength(300);

            // relationship
            builder.HasMany(b => b.BookingServices)
            .WithOne(s => s.Service)
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
