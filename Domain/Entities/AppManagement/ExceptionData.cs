using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.AppManagementEntities;

public partial class ExceptionData
{
    [Key]
    public int ExceptionDataId { get; set; }

    public int ExceptionId { get; set; }

    public string Key { get; set; } = null!;

    public string? Value { get; set; }
}
