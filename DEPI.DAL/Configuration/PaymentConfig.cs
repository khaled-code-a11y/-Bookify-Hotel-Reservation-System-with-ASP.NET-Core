using DEPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Configuration
{
    public class PaymentConfig : IEntityTypeConfiguration<PaymentModel>
    {
        public void Configure(EntityTypeBuilder<PaymentModel> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(py => py.PaymentID);

            builder.Property(py => py.PaymentID)
                .UseIdentityColumn(1, 1);

            builder.Property(py => py.Amount)
                .IsRequired();

            builder.Property(py => py.Amount)
               .IsRequired();

            builder.Property(py => py.Date)
               .IsRequired();

            builder.Property(py => py.PaymentMethod)
               .IsRequired();

            builder.Property(py => py.ReservedID)
               .IsRequired();


            builder.HasOne(p => p.ReservedroomModel)
        .WithMany(r => r.PaymentModel)
        .HasForeignKey(p => p.ReservedID);
      

        }
    }
}
