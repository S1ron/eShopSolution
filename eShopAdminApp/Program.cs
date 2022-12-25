using eShopAdminApp.Services;
using eShopViewModels.System.Users;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace eShopAdminApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var Configuration = builder.Configuration;

            //--------------------------------------------------
            //ConfigureServices(builder.Services) => service
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/Forbidden";
            });

            services.AddControllersWithViews()
                .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddTransient<IUserApiClient, UserApiClient>();

            IMvcBuilder mvcBuilder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#if DEBUG
            if(environment == Environments.Development)
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }
#endif

            //End ConfigureServices
            //-----------------------------------------------------

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

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}