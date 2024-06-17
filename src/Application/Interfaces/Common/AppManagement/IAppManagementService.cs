using Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common.AppManagement
{
    public interface IAppManagementService
    {
        public Task<AppManagementAuth> ValidateRequest(string apiKey);
    }
}
