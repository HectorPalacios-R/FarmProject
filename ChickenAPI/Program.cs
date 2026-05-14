
namespace ChickenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer(); // Required for Minimal APIs or routing discovery
            builder.Services.AddSwaggerGen();           // Registers the Swagger generator

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (true)
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(); // Serves the interactive web UI
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
