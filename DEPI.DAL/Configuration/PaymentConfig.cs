

namespace DEPI.DAL.Configuration
{
    public class PaymentConfig : IEntityTypeConfiguration<PaymentModel>
    {
        public void Configure(EntityTypeBuilder<PaymentModel> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(py => py.PaymentId);

            builder.Property(py => py.PaymentId)
                .UseIdentityColumn(1, 1);

            builder.Property(py => py.Amount)
                .IsRequired();

            builder.Property(py => py.Date)
               .IsRequired();

            builder.Property(py => py.PaymentMethod)
               .IsRequired();

            builder.Property(py => py.ReservedId)
               .IsRequired();


            builder.HasOne(p => p.ReservedRoom)
            .WithMany(r => r.Payment)
            .HasForeignKey(p => p.ReservedId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
