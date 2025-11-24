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
    public class ReservedRoomConfig : IEntityTypeConfiguration<ReservedroomModel>
    {
        public void Configure(EntityTypeBuilder<ReservedroomModel> builder)
        {
            builder.ToTable("ReservedRoom");

            builder.HasKey(rs => rs.ReservedID);

            builder.Property(rs => rs.ReservedID)
                .UseIdentityColumn(1, 1);

            builder.Property(rs => rs.CustomerID)
                .IsRequired();

            builder.Property(rs => rs.RoomID)
               .IsRequired();

            builder.Property(rs => rs.CheckIN)
               .IsRequired();

            builder.Property(rs => rs.CheckOUT)
               .IsRequired();


            builder.Property(rs => rs.Status)
               .IsRequired();

           
            builder.HasMany(b => b.Bookingservice)
             .WithOne(rs => rs.ReservedroomModel)
            .HasForeignKey(b => b.ReservedID)
            .OnDelete(DeleteBehavior.Cascade);



            builder.HasOne(r => r.Room)
           .WithMany(rs => rs.Reservedroom)
          .HasForeignKey(rs => rs.RoomID);



        }
    }
}
