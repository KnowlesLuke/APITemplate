using Domain.BaseEntities;

namespace Domain.Entities.ApiTemplate.Assets
{
    public class Status : BaseTableEntity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        // Reference Navigation Property
        public List<Asset> Asset { get; set; } = [];
    }
}
