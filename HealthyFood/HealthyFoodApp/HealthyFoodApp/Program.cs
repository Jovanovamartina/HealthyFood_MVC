using DataAccess;
using DataAccess.Abstraction;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction;
using Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHealthyFoodService,HealthyFoodService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IHealthyFoodOrderItemService, HealthyFoodOrderItemService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddScoped<IRepository<HealthyFood>, HealthyFoodRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<HealthyFoodOrderItem>, HealthyFoodOrderItemRepository>();
builder.Services.AddScoped<IRepository<Location>, LocationRepository>();

builder.Services.AddDbContext<DataBaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

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
