using Business.Abstract;
using Business.Concrete;
using Core.UnitOfWorks;
using Core.Utils.Helpers.TwilioSmsHelper;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
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
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<ITimer, TimerWrapper>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IScheduledTaskService, ScheduledTaskService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IPersonRepository, EfPersonRepository>();
builder.Services.AddScoped<IAttendanceRepository, EfAttendanceRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

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
