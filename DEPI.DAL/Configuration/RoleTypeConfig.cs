

namespace DEPI.DAL.Configuration
{
    public class RoleTypeConfig : IEntityTypeConfiguration<RoleTypeModel>
    {
        public void Configure(EntityTypeBuilder<RoleTypeModel> builder)
        {

            builder.ToTable("RoleTypes");

            builder.HasKey(rt => rt.TypeId);

            builder.Property(rt => rt.TypeId)
                .UseIdentityColumn(1, 1);

            builder.Property(rt => rt.TypeName).IsRequired().HasMaxLength(100);
            builder.HasIndex(rt => rt.TypeName).IsUnique();

            builder.Property(rt => rt.TypeDescription).HasMaxLength(250);

            //relation
            builder.HasMany(rt => rt.StaffMembers)
                .WithOne(s => s.RoleType)
                .HasForeignKey(s => s.TypeId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
