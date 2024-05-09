using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiTemplate.Assets
{
    // Called AssetType to avoid conflict with System.Type
    public class AssetType : BaseTableEntity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        // Reference Navigation Property
        public List<Asset> Asset { get; set; } = [];
    }
}
