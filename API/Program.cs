using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Infrastructure.Data;
using Infrastructure.Data.DbContextSetup;
using Infrastructure.Repositories.Common;
using Infrastructure.Services.Accounts;

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
builder.Services.AddScoped<ILoggingService, LoggingService>();

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
