using Microsoft.EntityFrameworkCore;
using ChickenAPI.Model;

namespace ChickenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FarmDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            // OpenAPI / Swagger
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Automatically create database/tables if they do not exist
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FarmDbContext>();

                db.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Chicken API v1");
                options.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}