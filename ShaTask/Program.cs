using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShaTask.Persistence.Data;
using ShaTask.Services;
using ShaTask.Services.Impelementaion;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// To Configure DbContext 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//-- Container
 builder.Services.AddScoped<IInvoicesOrdersService, IInvoicesOrdersImpl>();
builder.Services.AddScoped<ICityAndBranchAndCashierService ,CityAndBranchAndCashierImpl>();

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
