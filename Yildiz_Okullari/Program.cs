using Business.Abstract;
using Business.Concrete;
using Core.Utils.Helpers.TwilioSmsHelper;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRegisterService,RegisterService>();
builder.Services.AddScoped<ILoginService,LoginService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<Person,AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddTransient<ISmsService, SmsService>();

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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
