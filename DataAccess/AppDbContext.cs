using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<Person, AppRole, Guid>
    {
        public AppDbContext() : base()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
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

            builder.Entity<Person>().HasOne(p => p.FamilyInfo).WithMany(f => f.Persons).HasForeignKey(p => p.FamilyId);// person ile family info arasında one to many ilişki kurduk.
        }
        public DbSet<Person> Persons { get; set;}
		public DbSet<Attendance> Attendances { get; set;}
		public DbSet<Term> Terms { get; set;}
    }
}
