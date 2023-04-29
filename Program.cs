using Microsoft.EntityFrameworkCore;
using TesteFood.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//builder.Services.AddScoped<IRestaurantData, InMemoryRestaurantData>(); //To use In Memory Data
builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>(); //To use Local DB
builder.Services.AddDbContext<TesteFoodDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TesteFoodDb")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();