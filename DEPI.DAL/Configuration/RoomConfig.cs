

namespace DEPI.DAL.Configuration
{
    public class RoomConfig : IEntityTypeConfiguration<RoomModel>
    {
        public void Configure(EntityTypeBuilder<RoomModel> builder)
        {

            builder.ToTable("Rooms");

            builder.HasKey(r => r.RoomId);

            builder.Property(r => r.RoomId)
                .UseIdentityColumn(1, 1);

            builder.Property(r => r.isAvailable)
                .IsRequired();

            builder.Property(r => r.RoomNumber).IsRequired();
            builder.HasIndex(r => r.RoomNumber).IsUnique();

            //Relationships

            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.TypeId);

            builder.HasMany(r => r.ReservedRooms)
                .WithOne(rr => rr.Room)
                .HasForeignKey(rr => rr.RoomId);
        }
    }
}
