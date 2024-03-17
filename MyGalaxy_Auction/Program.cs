using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Abstraction;
using MyGalaxy_Auction_Business.Concrete;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_DataAccess.Context;
using MyGalaxy_Auction_DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

// dependency injection ile ilgili inteface'yi tetiklediðimiz zaman hangi sýnýfta bu interface metodunun override edildiðinin adresini belirtiyoruz.
// IUserService verilirse bunun adresinin UserService içerisinde olduðunu bil diyoruz.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(ApiResponse));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
