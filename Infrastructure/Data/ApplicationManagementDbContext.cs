using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities.AppManagementEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class ApplicationManagementDbContext : DbContext
{
    // Constructor for DbContext
    public ApplicationManagementDbContext(DbContextOptions<ApplicationManagementDbContext> options)
        : base(options)
    {
        // disable ef core migrations
        
    }

    /*
        * Entities are set here for use in Context throughout the app
        * We are ovveriding the default schema for each table using Fluent API in the Configurations Folder
        * Schema can also be set as Data Annotations in the Entity Class - Fluent API is the preferred method
    */

    // Reference to the ExceptionData Entity - Exceptions.Data Table in Database
    public virtual DbSet<ExceptionData> ExceptionData { get; set; }

    // Reference to the ApiKeyDetail Entity - ApiKeys.Details Table in Database
    public virtual DbSet<ApiKeyDetail> ApiKeyDetails { get; set; }

    // Reference to the ExceptionDetail Entity - Exceptions.Details Table in Database
    public virtual DbSet<ExceptionDetail> ExceptionDetails { get; set; }
}
