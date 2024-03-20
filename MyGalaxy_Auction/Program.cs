using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction.Extensions;
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


// veritabaný baðlantý iþlemini yani context'i ve AddIdentity'i AddPersistenceLayer içerisine yazýp buraya dahil ettik
builder.Services.AddPersistenceLayer(builder.Configuration);

//AddApplicationLayer adýnda bir middleware oluþturmuþ olduk.
//program.cs class'ý çok kalabalýk olmasýn diye burdaki bazý kodlarý AddApplicationLayer class'ýna taþýdýk
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddSwaggerCollection(builder.Configuration);

builder.Services.AddInfrastructreLayer(builder.Configuration);

builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

//Bunu ekledik.
app.UseAuthorization();

//Bunu ekledik. Vehicles tablosundaki imagelere eriþip onlarý görüntülemeyi saðlar.
app.UseStaticFiles();

app.MapControllers();

app.Run();
