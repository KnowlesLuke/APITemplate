using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AppManagementEntities;

// Set the schema for the ApiKeyDetail entity - Use data annotations for non-ef databases
[Table("Details", Schema = "ApiKeys")]
public class ApiKeyDetail
{
    [Key]
    public int ApiKeyId { get; set; }

    public string ApiKey { get; set; } = null!;

    public string PrivateKey { get; set; } = null!;

    public int? ApplicationId { get; set; }

    public string? AllowedHosts { get; set; }

    public int? ExpiryLimit { get; set; }

    public Guid ReadAction { get; set; }

    public Guid WriteAction { get; set; }

    // For audit purposes - Created date
    [DefaultValue("GETDATE()")]
    [DataType(DataType.DateTime)]
    public DateTime Created { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? Deleted { get; set; }
}
