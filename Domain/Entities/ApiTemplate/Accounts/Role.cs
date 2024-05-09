using Domain.BaseEntities.ApiTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiTemplate.Accounts
{
    public class Role : BaseTableEntity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        // Reference Navigation Property
        public List<Account> Account { get; set; }
    }
}
