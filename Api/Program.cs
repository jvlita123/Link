using Api.Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<AccountRepository>();
            builder.Services.AddScoped<AchievementService>();
            builder.Services.AddScoped<AchievementRepository>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<EmployeeRepository>();
            builder.Services.AddScoped<UserAchievementRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UserService>();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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