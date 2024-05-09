using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Accounts
{
    public record BaseAccount(string Forename, string Surname, string EmailAddress, string Username);
}
