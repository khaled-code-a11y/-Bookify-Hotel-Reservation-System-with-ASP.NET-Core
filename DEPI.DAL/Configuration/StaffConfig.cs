
namespace DEPI.DAL.Configuration
{
    public class StaffConfig : IEntityTypeConfiguration<StaffModel>
    {
        public void Configure(EntityTypeBuilder<StaffModel> builder)
        {

            builder.ToTable("Staffs");

            builder.HasKey(s => s.StaffId);

            builder.Property(s => s.StaffId)
                .UseIdentityColumn(1, 1);

            builder.Property(s => s.Salary)
              .IsRequired();

            builder.Property(s => s.UserId)
             .IsRequired();

            builder.Property(s => s.TypeId)
             .IsRequired();

            // Relationships
            builder.HasOne(s => s.User)
                 .WithOne(u => u.Staff)
                 .HasForeignKey<StaffModel>(s => s.UserId);

            builder.HasOne(s => s.RoleType)
                .WithMany(rt => rt.StaffMembers)
                .HasForeignKey(s => s.TypeId);



        }
    }
}
