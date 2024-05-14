using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AppManagementEntities;

// Set the schema for the ExceptionData entity - Use data annotations for non-ef databases
[Table("Data", Schema = "Exceptions")]
public class ExceptionData
{
    [Key]
    public int ExceptionDataId { get; set; }

    public int ExceptionId { get; set; }

    public string Key { get; set; } = null!;

    public string? Value { get; set; }
}
