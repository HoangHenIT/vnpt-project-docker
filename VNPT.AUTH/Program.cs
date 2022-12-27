using ClassLibrary.auth;
using ClassLibrary.connectdb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VNPT.AUTH.services.auth;
using VNPT.AUTH.services.auth.impl;
using VNPT.AUTH.services.roles;
using VNPT.AUTH.services.roles.impl;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnectionSQLServer"));
});

builder.Services.AddTransient<IRoler, RolerImpl>();
builder.Services.AddTransient<IAuth, AuthImpl>();
builder.Services.Configure<Audience>(configuration.GetSection("Audience"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
