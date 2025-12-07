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
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            // --- AutoMapper ---
            builder.Services.AddAutoMapper(typeof(RoomMap));

            // --- FluentValidation ---
            builder.Services.AddValidatorsFromAssemblyContaining<RoomValidation>();

            // --- Controllers ---
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            // --- DbContext ---
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // --- Swagger/OpenAPI ---
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "DEPI API",
                    Version = "v1",
                    Description = "API for Room Management System"
                });
            });

            // --- CORS (Important for Frontend) ---
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // ============================
            // Configure HTTP request pipeline
            // ============================

            // --- Enable Swagger in Development AND Production ---
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DEPI API v1");
                c.RoutePrefix = string.Empty; // Makes Swagger available at root URL
            });

            app.UseHttpsRedirection();

            // --- Enable CORS ---
            app.UseCors("AllowFrontend");
            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}