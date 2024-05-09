using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiTemplate.Accounts
{
    public class Account : BaseTableEntity
    {
        public required string Forename { get; set; }

        public required string Surname { get; set; }

        public required string DisplayName { get; set; }

        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }


        // Foreign Key
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
