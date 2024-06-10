using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Accounts
{
    // Optional Paraeters For Update Operation - ModifiedBy and Id are the only mandatory parameters
    public record AccountPut
    (
        int Id,
        string? Forename,
        string? Surname,
        string? Username,
        string? Email,
        int? RoleId,
        string ModifiedBy
    );
}
