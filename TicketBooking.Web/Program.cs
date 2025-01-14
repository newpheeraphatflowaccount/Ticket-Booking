using Microsoft.EntityFrameworkCore;
using TicketBooking.Repositories;
using TicketBooking.Repositories.Implementations;
using TicketBooking.Repositories.Interfaces;
using TicketBooking.Web.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TicketBooking.Web"));
});
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<ISeatDetailRepo, SeatDetailRepo>();
builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var config = new AutoMapper.MapperConfiguration(options =>
{
	options.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



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
