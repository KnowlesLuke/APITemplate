using Application.Interfaces.Accounts;
using Application.Interfaces.Common.AppManagement;
using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Infrastructure.Data;
using Infrastructure.Data.DbContextSetup;
using Infrastructure.Repositories.Accounts;
using Infrastructure.Repositories.Common;
using Infrastructure.Services.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
#endregion

#region Configure DbContexts

// Add APITemplate DbContext
builder.Services.ConfigureEfDefaults<APITemplateDbContext>(
    config, 
    "ApiTemplate",
    builder.Environment.IsDevelopment());

// Add AppManagement DbContext
builder.Services.ConfigureEfDefaults<ApplicationManagementDbContext>(
    config, 
    "AppManagement", 
    builder.Environment.IsDevelopment());

#endregion

#region Configure Environment Specific Behaviour with appsettings.json

config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Use appsettings.Development.json for development environment
if (builder.Environment.IsDevelopment())
{
    config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
else
{
    // Add appsettings production.json for production environment
    config
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
}

#endregion

#region Configure Services

// Add services to the container.
builder.Services.AddScoped<IAccountsReadService, AccountsReadService>();
builder.Services.AddScoped<IAccountsWriteService, AccountsWriteService>();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IAppManagementService, AppManagementService>();

#endregion

#region Configure Application Details IOptions

// Add functionality to inject IOptions<T>
builder.Services.AddOptions();

// Add Config object so it can be injected
builder.Services.Configure<AppDetails>(config.GetSection("ApplicationDetails"));

#endregion

#region Configure JWT Authentication

// Add JWT Authentication
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["AuthenticationSettings:Issuer"],
            ValidAudience = config["AuthenticationSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["AuthenticationSettings:SecretKey"]!))
        };
    });

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
