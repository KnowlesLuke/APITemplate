using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Accounts
{
    public record AccountRequest
    (
        string Forename,
        string Surname,
        string Username,
        string Email,
        int RoleId,
        string CreatedBy
    );
}
