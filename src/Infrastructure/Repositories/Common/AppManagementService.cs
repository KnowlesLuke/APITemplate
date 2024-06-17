using Application.Interfaces.Common.AppManagement;
using Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
    public class AppManagementService : IAppManagementService
    {
        public Task<AppManagementAuth> ValidateRequest(string apiKey)
        {
            throw new NotImplementedException();
        }
    }
}
