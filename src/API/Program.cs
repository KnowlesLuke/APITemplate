using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Infrastructure.Data;
using Infrastructure.Data.DbContextSetup;
using Infrastructure.Repositories.Accounts;
using Infrastructure.Repositories.Common;
using Infrastructure.Services.Accounts;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure DbContexts

// Add APITemplate DbContext
builder.Services.ConfigureEfDefaults<APITemplateDbContext>(
    builder.Configuration, 
    "ApiTemplate",
    builder.Environment.IsDevelopment());

// Add AppManagement DbContext
builder.Services.ConfigureEfDefaults<ApplicationManagementDbContext>(
    builder.Configuration, 
    "AppManagement", 
    builder.Environment.IsDevelopment());

#endregion

#region Configure Environment Specific Behaviour with appsettings.json

// Use appsettings.Development.json for development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
else
{
    // Add environment variables for production - Stored on the server
    builder.Configuration.AddEnvironmentVariables();
}

#endregion

#region Configure Services

// Add services to the container.
builder.Services.AddScoped<IAccountsReadService, AccountsReadService>();
builder.Services.AddScoped<IAccountsWriteService, AccountsWriteService>();
builder.Services.AddScoped<ILoggingService, LoggingService>();

#endregion

#region Configure Application Details IOptions

// Add functionality to inject IOptions<T>
builder.Services.AddOptions();

// Add Config object so it can be injected
builder.Services.Configure<AppDetails>(builder.Configuration.GetSection("ApplicationDetails"));

#endregion


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
