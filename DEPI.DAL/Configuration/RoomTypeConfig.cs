

namespace DEPI.DAL.Configuration
{
    public class RoomTypeConfig : IEntityTypeConfiguration<RoomTypeModel>
    {
        public void Configure(EntityTypeBuilder<RoomTypeModel> builder)
        {

            builder.ToTable("RoomTypes");

            builder.HasKey(rt => rt.TypeId);

            builder.Property(rt => rt.TypeId)
                .UseIdentityColumn(1, 1);

            builder.Property(rt => rt.RoomCapacity)
                .IsRequired();

            builder.Property(rt => rt.Price)
               .IsRequired();

            builder.Property(rt => rt.Description)
                .HasMaxLength(500);

            // Relationship
            builder.HasMany(rt => rt.Rooms)
                .WithOne(r => r.RoomType)
                .HasForeignKey(r => r.TypeId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
