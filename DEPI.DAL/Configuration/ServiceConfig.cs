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
    public class ServiceConfig : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.ServiceID);

            builder.Property(s =>s.ServiceID ).UseIdentityColumn(1, 1);

            builder.Property(s => s.ServiceType).IsRequired();

            builder.Property(s => s.ServicePrice).IsRequired();

            builder.Property(s => s.Description).IsRequired().HasMaxLength(100);

            builder.HasMany(b => b.BookingserviceModel)
            .WithOne(s => s.ServiceModel)
            .HasForeignKey(b => b.ServiceID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
