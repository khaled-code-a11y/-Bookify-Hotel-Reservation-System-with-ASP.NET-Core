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
    public class RoomConfig : IEntityTypeConfiguration<RoomModel>
    {
        public void Configure(EntityTypeBuilder<RoomModel> builder)
        {

            builder.ToTable("Rooms");

            builder.HasKey(r => r.RoomId);

            builder.Property(r => r.RoomId)
                .UseIdentityColumn(1, 1);

            builder.Property(r => r.isAvailable)
                .IsRequired();

            builder.Property(r => r.RoomNumber)
                .IsRequired();

            //Relationship 
            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.TypeId);

        }
    }
}
