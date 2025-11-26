

namespace DEPI.DAL.Configuration
{
    public class ReservedRoomConfig : IEntityTypeConfiguration<ReservedroomModel>
    {
        public void Configure(EntityTypeBuilder<ReservedroomModel> builder)
        {
            builder.ToTable("ReservedRooms");

            builder.HasKey(rs => rs.ReservedId);

            builder.Property(rs => rs.ReservedId)
                .UseIdentityColumn(1, 1);

            builder.Property(rs => rs.CustomerId)
                .IsRequired();

            builder.Property(rs => rs.RoomId)
               .IsRequired();

            builder.Property(rs => rs.CheckIN)
               .IsRequired();

            builder.Property(rs => rs.CheckOUT)
               .IsRequired();


            builder.Property(rs => rs.Status)
               .IsRequired();


            // relationships

            builder.HasMany(b => b.BookingService)
             .WithOne(rs => rs.ReservedRoom)
             .HasForeignKey(b => b.ReservedId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Room)
           .WithMany(rs => rs.ReservedRooms)
           .HasForeignKey(rs => rs.RoomId);

            builder.HasOne(r => r.Customer)
            .WithMany(c => c.ReservedRooms)
            .HasForeignKey(r => r.CustomerId);

            builder.HasMany(r => r.Payment)
            .WithOne(p => p.ReservedRoom)
            .HasForeignKey(p => p.ReservedId)
            .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
