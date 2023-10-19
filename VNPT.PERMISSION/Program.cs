using ClassLibrary.auth.hashpass;
using ClassLibrary.connectdb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using VNPT.PERMISSION.services.impl;
using VNPT.PERMISSION.services;
using VNPT.AUTH.services.roles.impl;
using VNPT.AUTH.services.roles;
using VNPT.PERMISSION.services.permission;
using VNPT.PERMISSION.services.permission.impl;

    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;


    var audienceConfig = configuration.GetSection("Audience");
    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        ValidateIssuer = true,
        ValidIssuer = audienceConfig["Iss"],
        ValidateAudience = true,
        ValidAudience = audienceConfig["Aud"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        RequireExpirationTime = true,
    };

    // Adding Authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "TestKey";
    })
     .AddJwtBearer("TestKey", x =>
     {
         x.RequireHttpsMetadata = false;
         x.TokenValidationParameters = tokenValidationParameters;
     });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();


    builder.Services.AddDbContext<DataContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnectionSQLServer"));
    });

    // Add services to the container.
    builder.Services.AddControllers();


    builder.Services.AddTransient<ICategoryMenu, CategoryMenuImpl>();
    builder.Services.AddTransient<IRoler, RolerImpl>();
    builder.Services.AddTransient<IRolePermission, RolePermisionImpl>();
    builder.Services.AddTransient<IEmployPermission, EmployPermissionImpl>();

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();