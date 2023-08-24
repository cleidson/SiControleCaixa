using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.BusinessServices.Services;
using SiControleCaixa.Infrastructure.Data.Context;
using SiControleCaixa.Infrastructure.Data.Models;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using SiControleCaixa.Infrastructure.Data.Repository.Repositories;
using System.Text;

namespace SiControleCaixa.ApplicationCore.IoC
{
    public static class Startup
    {
        public static void RegisterServices(this IServiceCollection services)
		{
			try
			{ 
                services.AddScoped<ITransactionService, TransactionService>();
                services.AddScoped<IAccountService, AccountService>(); 
                services.AddScoped<ITransacaoRepository, TransacaoRepository>();
                services.AddScoped<SiControleCaixaSqlContext>();

                
                //services.AddIdentity<IdentityUser, IdentityRole>()
                //                .AddEntityFrameworkStores<SiControleCaixaSqlContext>()
                //                .AddDefaultTokenProviders(); 
            }
			catch (Exception)
			{

				throw;
			}
        }

        public static IdentityBuilder AddApplicationIdentity(this IServiceCollection services)
        {
            return services.AddDefaultIdentity<IdentityUser>(options =>
            {
                // configuration can be written here:
                // builder.Services.Configure<IdentityOptions>
                options.SignIn.RequireConfirmedAccount = true;

                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SiControleCaixaSqlContext>();
        }

        public static IServiceCollection AddApplicationCookieAuth(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "My_Cookie_Name_In_Browser";
                    // Cookie settings
                    // configuration can be written here:
                    // builder.Services.ConfigureApplicationCookie

                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.SlidingExpiration = true;
                });

            return services;
        }

        public static IServiceCollection AddApplicationJwtAuth(this IServiceCollection services, JwtConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.Issuer,
                        ValidAudience = configuration.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key))
                    };
                });

            return services;
        }

    }
}