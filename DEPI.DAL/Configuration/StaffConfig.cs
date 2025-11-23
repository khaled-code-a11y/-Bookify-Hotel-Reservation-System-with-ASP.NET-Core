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

            builder.Property(s => s.UserID)
             .IsRequired();

            builder.Property(s => s.TypeId)
             .IsRequired();

            // Relationships
            builder.HasOne(s => s.User)
                 .WithOne(u => u.Staff)
                 .HasForeignKey<StaffModel>(s => s.UserID);

            builder.HasOne(s => s.RoleType)
                .WithMany(rt=>rt.StaffMembers)
                .HasForeignKey(s=>s.TypeId);



        }
    }
}
