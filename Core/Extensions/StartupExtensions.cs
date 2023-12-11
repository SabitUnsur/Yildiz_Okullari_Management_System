using Core.Validations;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public  static class StartupExtensions
    {
        // AddIdentityWithExtension methodunu program.cs de yazmak yerine burada yazdık.
        //AddIdentity methodu ile Identity servislerini ekledik.
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan=TimeSpan.FromHours(1);
            });
            // AddIdentity methodu ile Identity servislerini ekledik.
            //password ayarları için PasswordValidator ve UserValidator sınıflarını ekledik.
            services.AddIdentity<Person, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength=6;
                options.Password.RequireNonAlphanumeric=false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
