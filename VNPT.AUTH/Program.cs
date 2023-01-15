using ClassLibrary.auth;
using ClassLibrary.connectdb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VNPT.AUTH.services.auth;
using VNPT.AUTH.services.auth.impl;
using VNPT.AUTH.services.roles;
using VNPT.AUTH.services.roles.impl;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Adding Authentication
var audienceConfig = configuration.GetSection("Audience");
var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = signingKey,
    ValidateIssuer = true,
    ValidIssuer = audienceConfig["Issuer"],
    ValidateAudience = true,
    ValidAudience = audienceConfig["Aud"],
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero,
    RequireExpirationTime = true,
};


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "KeyAuthenticate";
})
 .AddJwtBearer("KeyAuthenticate", x =>
 {
     x.RequireHttpsMetadata = false;
     x.TokenValidationParameters = tokenValidationParameters;
 });
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
builder.Services.AddTransient<IHistoryLogins, HistoryLoginsImpl>();
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
