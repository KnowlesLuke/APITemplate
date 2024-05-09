using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities.ApiTemplate
{
    public abstract class BaseTableEntity
    {
        /*
         * Setting up the base table entity for all entities 
         * Using data annotations instead of FLuent API For Base Class due to the nature of the class
        */

        // Id is the primary key for all entities
        [Key]
        public int Id { get; set; }

        // Version is used for optimistic concurrency
        [Timestamp]
        public byte[] Version { get; set; }

        // For audit purposes - Created date
        public DateTime Created { get; set; } = DateTime.Now;

        // For audit purposes
        public required string CreatedBy { get; set; }

        // For audit purposes
        public DateTime? Modified { get; set; }

        // For audit purposes
        public string? ModifiedBy { get; set; }

        // Soft delete
        public DateTime? Deleted { get; set; }

        // For audit purposes
        public string? DeletedBy { get; set; }
    }
}
