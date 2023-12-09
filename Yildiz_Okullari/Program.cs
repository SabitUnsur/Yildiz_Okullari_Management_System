using Business.Abstract;
using Business.Concrete;
using Core.Extensions;
using Core.OptionsModel;
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
builder.Services.AddScoped<IEmailService,EmailService>();


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings")); //IOptionsEmailSettings e�er bir constructor i�erisinde kullan�lacaksa bu �ekilde tan�mlan�r


builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentityWithExtension();// bu metot Core katman�ndaki Extensions klas�r�ndeki StartupExtensions.cs dosyas�nda tan�ml�d�r
builder.Services.Configure<SecurityStampValidatorOptions>(options => //validation interval �zelli�i �u i�e yarar : kullan�c� �ifresini de�i�tirdi�inde kullan�c�n�n di�er oturumlar�n� kapat�r
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
	pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
