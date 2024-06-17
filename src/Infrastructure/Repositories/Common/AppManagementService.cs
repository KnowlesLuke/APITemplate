using Application.Interfaces.Common.AppManagement;
using Application.Models.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
    public class AppManagementService : IAppManagementService
    {
        // Database context
        private readonly ApplicationManagementDbContext _context;

        public AppManagementService(ApplicationManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AppManagementAuth> ValidateRequest(string apiKey, Guid action)
        {
            // Get the application and api key details
            var appDetail = await 
                _context.ApiKeyDetails
                .FirstOrDefaultAsync(x => x.ApiKey == apiKey);

            // Check if appDetail is null
            if (appDetail == null)
                return null;

            // Check if the action matches either the read or write action
            bool validAction = appDetail.ReadAction == action || appDetail.WriteAction == action;

            // If the action is not valid, return null
            if (!validAction)
                return null;

            // Check if the action matches the read action
            bool canWrite = appDetail.WriteAction == action;

            // Return the app details
            return new AppManagementAuth
            (
                publicKey: appDetail.ApiKey,
                secretKey: appDetail.PrivateKey,
                canWrite: canWrite
            );
        }
    }
}
