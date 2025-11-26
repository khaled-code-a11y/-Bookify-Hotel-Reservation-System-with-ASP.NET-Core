
namespace DEPI.DAL.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {

            builder.ToTable("Customers");

            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                .UseIdentityColumn(1, 1);

            builder.Property(c => c.UserId)
                .IsRequired();

            // relationships
            builder.HasOne(c => c.User)
             .WithOne(u => u.Customer)
             .HasForeignKey<CustomerModel>(c => c.UserId);

            builder.HasMany(c => c.ReservedRooms)
             .WithOne(r => r.Customer)
             .HasForeignKey(r => r.CustomerId);

        }
    }
}