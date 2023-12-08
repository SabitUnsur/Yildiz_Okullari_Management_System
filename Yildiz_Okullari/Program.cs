using Business.Abstract;
using Business.Concrete;
using Core.Extensions;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRegisterService,RegisterService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IRoleService,RoleService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<Person,AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityWithExtension();// bu metot Core katmanýndaki Extensions klasöründeki StartupExtensions.cs dosyasýnda tanýmlýdýr
builder.Services.Configure<SecurityStampValidatorOptions>(options => //validation interval özelliði þu iþe yarar : kullanýcý þifresini deðiþtirdiðinde kullanýcýnýn diðer oturumlarýný kapatýr
{
    options.ValidationInterval = TimeSpan.FromMinutes(30);
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
