using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEPI.DAL.Configuration;
using DEPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DEPI.DAL
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<StaffModel> Staffs { get; set; }
        public DbSet<RoleTypeModel> RoleTypes { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }


    }
}
