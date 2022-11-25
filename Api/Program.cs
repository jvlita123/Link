using Api.Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Service.Services;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
                });
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Forbidden/";
            });

            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<AccountRepository>();
            builder.Services.AddScoped<AchievementService>();
            builder.Services.AddScoped<AchievementRepository>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<EmployeeRepository>();
            builder.Services.AddScoped<MatchService>();
            builder.Services.AddScoped<MatchRepository>();
            builder.Services.AddScoped<MatchHistoryService>();
            builder.Services.AddScoped<MatchHistoryRepository>();
            builder.Services.AddScoped<MessageService>();
            builder.Services.AddScoped<MessageRepository>();
            builder.Services.AddScoped<PhotoService>();
            builder.Services.AddScoped<PhotoRepository>();
            builder.Services.AddScoped<ReactionService>();
            builder.Services.AddScoped<ReactionRepository>();
            builder.Services.AddScoped<RelationService>();
            builder.Services.AddScoped<RelationRepository>();
            builder.Services.AddScoped<StatusService>();
            builder.Services.AddScoped<StatusRepository>();
            builder.Services.AddScoped<StoryService>();
            builder.Services.AddScoped<StoryRepository>();
            builder.Services.AddScoped<UserAchievementService>();
            builder.Services.AddScoped<UserAchievementRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();


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

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseHttpsRedirection();

            app.UseCors("CORSPolicy");

            app.Run();
        }
    }
}