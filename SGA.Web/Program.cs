using Microsoft.EntityFrameworkCore;
using SGA.Persistence.Context;
using SGA.Infraestructure.Dependencies.Bus;
using SGA.Infraestructure.Dependencies.Ruta;
namespace SGA.Web
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



            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
