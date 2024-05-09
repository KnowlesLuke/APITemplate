using Domain.BaseEntities.ApiTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiTemplate.Assets
{
    // Entity For Details Table In Database
    public class Asset : BaseTableEntity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Value { get; set; }

        public bool ReadOnly { get; set; }


        // Foreign Key
        public int StatusId { get; set; }

        public Status Status { get; set; }


        // Foreign Key
        public int AssetTypeId { get; set; }

        public AssetType AssetType { get; set; }
    }
}
