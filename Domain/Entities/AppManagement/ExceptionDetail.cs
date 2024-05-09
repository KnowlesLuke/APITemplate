using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.AppManagementEntities;

public partial class ExceptionDetail
{
    [Key]
    public int ExceptionId { get; set; }

    public string ExceptionType { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? Source { get; set; }

    public int? HResult { get; set; }

    public string? TargetSite { get; set; }

    public string? HelpLink { get; set; }

    public string? StackTrace { get; set; }

    public int? InnerExceptionId { get; set; }

    public string ApplicationName { get; set; } = null!;

    [DefaultValue("GETDATE()")]
    [DataType(DataType.DateTime)]
    public DateTime DateTime { get; set; }
}
