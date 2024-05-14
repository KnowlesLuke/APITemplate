using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Accounts
{
    // Contract that is returned on successful account creation and update
    public record AccountResponse
    (
        int Id,
        string Forename,
        string Surname,
        string DisplayName,
        string Username,
        string Email,
        int RoleId,
        DateTime Created,
        DateTime? Modified
    );
}
