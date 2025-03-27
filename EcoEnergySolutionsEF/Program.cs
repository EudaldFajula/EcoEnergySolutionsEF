using EcoEnergySolutionsEF.data;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergySolutionsEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registra el DbContext amb la cadena de connexió
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                var appInitializer = new AppDbInitializer(context);
                appInitializer.Seed();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
