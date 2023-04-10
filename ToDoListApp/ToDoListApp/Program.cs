using Microsoft.AspNetCore.Authentication.Negotiate;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ToDoListApp.Data;

namespace ToDoListApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();


            //bankai 
            // builder services!!!!!
            builder.Services.AddSingleton<DapperContext>();
            //!!!!!
            builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
            builder.Services.AddControllers();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });
            builder.Services.AddRazorPages();

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
                pattern: "{controller=ToDoList}/{action=Index}/{id?}");

            app.Run();
        }
    }
}