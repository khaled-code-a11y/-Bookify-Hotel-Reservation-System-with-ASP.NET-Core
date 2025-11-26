
namespace DEPI.DAL.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                .UseIdentityColumn(1, 1);

            builder.Property(u => u.NationalId)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(u => u.NationalId)
                .IsUnique();

            builder.Property(u => u.Name)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(u => u.Email)
              .IsRequired()
              .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
              .IsUnique();

            builder.Property(u => u.Password)
              .IsRequired()
              .HasMaxLength(255);

            builder.Property(u => u.Phone)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(u => u.DOB)
              .IsRequired()
              .HasColumnType("date");

            builder.Property(u => u.Gender)
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(u => u.Address)
              .HasMaxLength(200);


            // Relationships
            builder.HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<CustomerModel>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Staff)
                .WithOne(s => s.User)
                .HasForeignKey<StaffModel>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
