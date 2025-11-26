


namespace DEPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<StaffModel> Staffs { get; set; }
        public DbSet<RoleTypeModel> RoleTypes { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }
        public DbSet<BookingServiceModel> bookingServices { get; set; }
        public DbSet<PaymentModel> payments { get; set; }
        public DbSet<ReservedroomModel> reservedrooms { get; set; }
        public DbSet<ServiceModel> services { get; set; }






    }
}
