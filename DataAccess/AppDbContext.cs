using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<Person, AppRole, Guid>
    {
        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("SqlConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //SeedUsers(builder);
        }
       
        

        //private void SeedUsers(ModelBuilder modelBuilder)
        //{
        //    // Seed data 
        //    modelBuilder.Entity<Person>().HasData(
        //        new Person
        //        {
        //            Id = Guid.NewGuid(),
        //            AccessFailedCount = 0,
        //            BirthDate = DateTime.UtcNow,
        //            ConcurrencyStamp = Guid.NewGuid().ToString(),
        //            UserName = "example@example.com",
        //            Grade = 12,
        //            Branch = "B",
        //            NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
        //            Email = "example@example.com",
        //            NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
        //            EmailConfirmed = true,
        //            PasswordHash = new PasswordHasher<Person>().HashPassword(null, "123456789"),
        //            LockoutEnd = DateTime.MaxValue,
        //            LockoutEnabled = false,
        //            SecurityStamp = Guid.NewGuid().ToString(),
        //            TwoFactorEnabled = false,
        //            Name = "Sabit",
        //            Surname = "Ünsür",
        //            PhoneNumber = "+905423849022",
        //            PhoneNumberConfirmed = true,
        //            StudentNumber = 653,
        //            //TermId = Guid.NewGuid(),
        //        }
        //    );

        //    modelBuilder.Entity<Person>().HasData(
        //        new Person
        //        {
        //            Id = Guid.NewGuid(),
        //            AccessFailedCount = 0,
        //            BirthDate = DateTime.UtcNow,
        //            ConcurrencyStamp = Guid.NewGuid().ToString(),
        //            UserName = "admin@admin.com",
        //            NormalizedUserName = "ADMIN@ADMIN.COM",
        //            Email = "admin@admin.com",
        //            NormalizedEmail = "ADMIN@ADMIN.COM",
        //            EmailConfirmed = true,
        //            PasswordHash = new PasswordHasher<Person>().HashPassword(null, "admin"),
        //            LockoutEnd = DateTime.MaxValue,
        //            LockoutEnabled = false,
        //            SecurityStamp = Guid.NewGuid().ToString(),
        //            TwoFactorEnabled = false,
        //            Name = "Admin",
        //        }
        //    );

        //    modelbuilder.Entity<Person>().HasData(
        //                   new Person
        //                   {
        //                       Id = Guid.NewGuid(),
        //                       AccessFailedCount = 0,
        //                       BirthDate = DateTime.UtcNow,
        //                       ConcurrencyStamp = Guid.NewGuid().ToString(),
        //                       UserName = "sabit@sabit.com",
        //                       Grade = 11,
        //                       Branch = "A",
        //                       NormalizedUserName = "SABIT@SABIT.COM",
        //                       Email = "sabit@sabit.com",
        //                       NormalizedEmail = "SABIT@SABIT.COM",
        //                       EmailConfirmed = true,
        //                       PasswordHash = new PasswordHasher<Person>().HashPassword(null, "147852369"),
        //                       LockoutEnd = DateTime.MaxValue,
        //                       LockoutEnabled = false,
        //                       SecurityStamp = Guid.NewGuid().ToString(),
        //                       TwoFactorEnabled = false,
        //                       Name = "Egemen",
        //                       Surname = "Ünsür",
        //                       PhoneNumber = "+905423849022",
        //                       PhoneNumberConfirmed = true,
        //                       StudentNumber = 1532,
        //                      // TermId = Guid.NewGuid(),
        //                   }
        //               );

        //    modelBuilder.Entity<Person>().HasData(
        //                  new Person
        //                  {
        //                      Id = Guid.NewGuid(),
        //                      AccessFailedCount = 0,
        //                      BirthDate = DateTime.UtcNow,
        //                      ConcurrencyStamp = Guid.NewGuid().ToString(),
        //                      UserName = "mikdat@simsek.com",
        //                      Grade = 12,
        //                      Branch = "C",
        //                      NormalizedUserName = "MIKDAT@MIKDAT.COM",
        //                      Email = "mikdat@simsek.com",
        //                      NormalizedEmail = "MIKDAT@MIKDAT.COM",
        //                      EmailConfirmed = true,
        //                      PasswordHash = new PasswordHasher<Person>().HashPassword(null, "mikdat123"),
        //                      LockoutEnd = DateTime.MaxValue,
        //                      LockoutEnabled = false,
        //                      SecurityStamp = Guid.NewGuid().ToString(),
        //                      TwoFactorEnabled = false,
        //                      Name = "Mikdat Can",
        //                      Surname = "Şimşek",
        //                      PhoneNumber = "+905397159877",
        //                      PhoneNumberConfirmed = true,
        //                      StudentNumber = 16,
        //                     // TermId = Guid.NewGuid(),
        //                  }
        //              );

        //    modelBuilder.Entity<Term>().HasData(
        //        new Term
        //        {
        //            Id = Guid.NewGuid(),
        //            EndDate = DateTime.MaxValue,
        //            StartDate = DateTime.UtcNow,
        //        }
        //    );

        //    modelBuilder.Entity<AppRole>().HasData(
        //        new AppRole
        //        {
        //            Id = Guid.NewGuid(),
        //            ConcurrencyStamp = Guid.NewGuid().ToString(),
        //            Name = "admin",
        //            NormalizedName = "ADMIN"
        //        }
        //    );
        //}


        public DbSet<Person> Persons { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<FamilyInfo> FamilyInfos { get; set; }
    }
}
