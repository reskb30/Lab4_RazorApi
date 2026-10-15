using Lab4_RazorApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers(); 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=postgres;Database=postgres;"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); 

app.Run();