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
    public class BookingServiceConfig : IEntityTypeConfiguration<BookingserviceModel>
    {
        public void Configure(EntityTypeBuilder<BookingserviceModel> builder)
        {
            builder.ToTable("BookingServise"); 

            builder.HasKey(b => b.BookingServiceID); 

            builder.Property(b => b.BookingServiceID).UseIdentityColumn(1, 1); 

            builder.Property(b => b.BookingServiceID).IsRequired(); 

            builder.Property( b=> b.ReservedID).IsRequired(); 

            builder.Property(b => b.Quantity).IsRequired();



            builder.HasOne(s => s.ServiceModel)
          .WithMany(b => b.BookingserviceModel)
          .HasForeignKey(b => b.ServiceID);


            builder.HasOne(rs => rs.ReservedroomModel)
             .WithMany(b => b.Bookingservice)
            .HasForeignKey(b => b.ReservedID);

            builder.HasOne(rs => rs.ReservedroomModel)
            .WithMany(b => b.Bookingservice)
           .HasForeignKey(b => b.ReservedID);

        }
    }
}
