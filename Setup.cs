using Microsoft.EntityFrameworkCore;
using TrinityAPI.Database.Context;
using TrinityAPI.Database.Factory;
using TrinityAPI.Services;

namespace TrinityAPI
{
    public class Setup
    {
        public void SetupService(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var host = "DB";
            var name = "Game";
            var pass = "S74nkm4m1";
            string[] connectionStrings = new string[]
            {
                "Data Source=" + host + ";Initial Catalog=" + name + ";User ID=sa;Password=" + pass + ";trusted_connection=true;integrated security=false;TrustServerCertificate=true;encrypt=false"
            };
            // Add services to the container.
            builder.Services.AddControllers();
            ///Game
            builder.Services.AddDbContext<ContextGame>(options => options.UseSqlServer(connectionStrings[0]), optionsLifetime: ServiceLifetime.Singleton);
            builder.Services.AddSingleton(new ServiceConfiguration(connectionStrings));
            builder.Services.AddSingleton<IDbContextFactory<ContextGame>, FactoryGame>();
            builder.Services.AddSingleton<ServiceGameDatabase>();
             
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ContextGame>();
                context.Database.EnsureCreated();
            }
             
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
