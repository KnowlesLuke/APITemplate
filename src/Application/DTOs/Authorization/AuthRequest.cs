using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Authorization
{
    // Contract for authorizing a request
    public record AuthRequest
    (
        string Name,
        string SecretKeyHash,
        string PublicKey,
        Guid Action
    );
}
