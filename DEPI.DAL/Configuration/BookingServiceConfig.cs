

namespace DEPI.DAL.Configuration
{
    public class BookingServiceConfig : IEntityTypeConfiguration<BookingServiceModel>
    {
        public void Configure(EntityTypeBuilder<BookingServiceModel> builder)
        {
            builder.ToTable("BookingServices");

            builder.HasKey(b => b.BookingServiceId);

            builder.Property(b => b.BookingServiceId).UseIdentityColumn(1, 1);

            builder.Property(b => b.ReservedId).IsRequired();

            builder.Property(b => b.Quantity).IsRequired();



            builder.HasOne(s => s.Service)
          .WithMany(b => b.BookingServices)
          .HasForeignKey(b => b.ServiceId);

            builder.HasOne(rs => rs.ReservedRoom)
             .WithMany(b => b.BookingService)
            .HasForeignKey(b => b.ReservedId);



        }
    }
}
