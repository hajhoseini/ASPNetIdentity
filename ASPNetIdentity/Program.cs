using ASPNetIdentity.InfraStructures;
using ASPNetIdentity.InfraStructures.Requirment;
using ASPNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPNetIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppIdentityDbContext>(c =>
            {
                c.UseSqlServer("Data Source=DPK-115\\SQL2017;Initial Catalog=AppIdentityDb;User ID=sa;Password=Dpk@12345;TrustServerCertificate=True");
            });

            builder.Services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator2>();
            builder.Services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();

            //builder.Services.AddIdentity<AppUser, AppRole>(
            builder.Services.AddIdentity<AppUser, IdentityRole>(
                                                config =>
                                                {
                                                    config.Password.RequireDigit = true;
                                                    config.Password.RequiredLength = 6;
                                                    config.Password.RequireNonAlphanumeric = false;
                                                    config.Password.RequiredUniqueChars = 0;
                                                    config.Password.RequireLowercase = false;
                                                    config.Password.RequireUppercase = false;
                                                    //config.User.AllowedUserNameCharacters = "abcd123";
                                                    config.User.RequireUniqueEmail = true;
                                                }
                                        ).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();
            builder.Services.ConfigureApplicationCookie(c => {
                                                                //c.AccessDeniedPath = "";
                                                                //c.Cookie
                                                                //c.LoginPath = 
                                                             });

            builder.Services.AddAuthorization(c =>
            {
                /*c.AddPolicy("CheckHireDate", d =>
                {
                    d.RequireAuthenticatedUser();
                    d.RequireRole("Admin");
                    d.RequireClaim("HireDate", "1396-01-01", "1396-02-01");
                    d.RequireAssertion(f => {
                        var date = DateTime.Parse(f.User.Claims.First(c => c.Type == "HireDate").Value);
                        var result = DateTime.Now - date;
                        return result.Days > 90;
                    });
                });
                c.AddPolicy("Requirment", d => {
                    d.Requirements.Add(new CustomeRequirment
                    {
                        Name = "ali"
                    });

                });*/
                c.AddPolicy("AuditRequirment", d => {
                    d.Requirements.Add(new AuditRequirment());

                });
            });

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}