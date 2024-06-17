using Domain.BaseEntities.ApiTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiTemplate.Accounts
{
    public class Account : BaseTableEntity
    {
        public required string Forename { get; set; }

        public required string Surname { get; set; }

        public string DisplayName { get; private set; } = "";

        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public Guid Token { get; set; } = Guid.NewGuid();

        // Foreign Key
        public int RoleId { get; set; }

        public Role Role { get; set; }

        // Update Account entity
        public void UpdateAccountEntity(Account updatedAccount)
        {
            // Loop through properties of Account entity
            foreach (var property in typeof(Account).GetProperties())
            {
                // Get value of property from updated account
                var value = property.GetValue(updatedAccount);

                // Get property type
                var propertyType = property.PropertyType;

                // If string
                if (propertyType == typeof(string))
                {
                    // If value is not null, update property value
                    if (value != null)
                    {
                        property.SetValue(this, value);
                    }
                }

                // If int
                if (propertyType == typeof(int))
                {
                    // If value is not 0, update property value
                    if ((int)value != 0)
                    {
                        property.SetValue(this, value);
                    }
                }
            }
        }

        // Set display name
        public void SetDisplayName()
        {
            DisplayName = $"{Forename} {Surname}";
        }
    }
}
