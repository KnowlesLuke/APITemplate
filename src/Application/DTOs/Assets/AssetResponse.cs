using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Assets
{
    /*
     * Using Record Types which are immutable
     * This DTO is used to map the response from the domain entity
     * This is the contract between the API and the client - The API will send this data to the client
    */

    public record AssetResponse
    (
        int Id,
        string Name,
        string Description,
        decimal Value,
        bool ReadOnly,
        int StatusId,
        int AssetTypeId,
        DateTime Created
    );
}
