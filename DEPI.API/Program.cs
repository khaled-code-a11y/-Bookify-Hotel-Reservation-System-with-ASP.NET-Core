
namespace DEPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ============================
            // Add services to the container
            // ============================

            // --- Repository & Service ---
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            // --- AutoMapper ---
            builder.Services.AddAutoMapper(typeof(RoomMap));

            // --- FluentValidation ---
            builder.Services.AddValidatorsFromAssemblyContaining<RoomValidation>();

            // --- Controllers ---
            builder.Services.AddControllers();

            // --- DbContext ---
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
             options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
             options.JsonSerializerOptions.WriteIndented = true;
            });
            var app = builder.Build();

            // ============================
            // Configure HTTP request pipeline
            // ============================

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
