
using Microsoft.EntityFrameworkCore;
using SGA.Application.Interfaces;
using SGA.Application.Repositories.Confguration;
using SGA.Application.Services;
using SGA.Persistence.Context;
using SGA.Persistence.Repositories.Configuration;
using SGA.Infraestructure.Dependencies.Bus;
using SGA.Infraestructure.Dependencies.Ruta;
namespace SGA.Configuration.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<SGAContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SgaConnString")));

            builder.Services.AddBusDependencies();
            builder.Services.AddRutaDependencies();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
