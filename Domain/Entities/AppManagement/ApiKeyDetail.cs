﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.AppManagementEntities;

public class ApiKeyDetail
{
    [Key]
    public int ApiKeyId { get; set; }

    public string ApiKey { get; set; } = null!;

    public string? PrivateKey { get; set; }

    public int? ApplicationId { get; set; }

    public string? AllowedHosts { get; set; }

    public int? ExpiryLimit { get; set; }

    // For audit purposes - Created date
    [DefaultValue("GETDATE()")]
    [DataType(DataType.DateTime)]
    public DateTime Created { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? Deleted { get; set; }
}
