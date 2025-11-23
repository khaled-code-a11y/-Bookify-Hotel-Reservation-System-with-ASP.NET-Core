using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(c => c.UserID)
                .IsRequired();

            // relationships
            builder.HasOne(c => c.User)
                       .WithOne(u => u.Customer)
                       .HasForeignKey<CustomerModel>(c => c.UserID);
        }
    }
}