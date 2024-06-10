using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Assets
{
    /* 
     * Using Record Types which are immutable
     * This DTO is used to map the request to the domain entity
     * This is the contract between the client and the API - The client will send this data to the API
     * Due to this, it should not be changed unless the changes are communicated to the client
    */

    public record AssetRequest
    (
        string Name,
        string Description,
        decimal Value,
        bool ReadOnly,
        int StatusId,
        int AssetTypeId
    );
}
