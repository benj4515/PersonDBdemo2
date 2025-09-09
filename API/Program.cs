using DataAccess;
using Microsoft.EntityFrameworkCore;
using personsDBdemo;
using Service;



public static class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        Configure(app);
    }

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<MyDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("Db")));

        services.AddScoped<IPetService, PetService>();

        services.AddOpenApiDocument();
        services.AddControllers();

        // 🔹 Tilføj CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // din frontend
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }

    public static void Configure(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
           
        }

        app.UseOpenApi();
        app.UseSwaggerUi();

        // 🔹 Brug CORS (skal stå før MapControllers)
        app.UseCors("AllowFrontend");

        app.MapControllers();

        app.Run();
    }
}