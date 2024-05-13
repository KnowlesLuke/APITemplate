using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Domain.Entities.AppManagementEntities;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
    public class LoggingService : ILoggingService
    {
        // Database context
        private readonly ApplicationManagementDbContext _context;

        // Application Details
        private readonly IOptions<AppDetails> _applicationDetails;

        // Application Name
        private readonly string AppName;

        public LoggingService(ApplicationManagementDbContext context, IOptions<AppDetails> applicationDetails)
        {
            _context = context;
            _applicationDetails = applicationDetails;

            // Check if application details are null
            if (_applicationDetails == null)
                throw new ArgumentNullException(nameof(applicationDetails));

            // Check if application name is null or empty
            if (string.IsNullOrEmpty(_applicationDetails.Value.Name))
                throw new ArgumentNullException(nameof(_applicationDetails.Value.Name));

            // Set application name
            AppName = _applicationDetails.Value.Name;
        }

        public async Task LogError(string process, string message, Exception ex)
        {
            try
            {
                // Log error to database
                await _context.ExceptionDetails.AddAsync(new ExceptionDetail
                {
                    ExceptionType = ex.GetType().ToString(),
                    Message = message,
                    Source = ex.Source,
                    HResult = ex.HResult,
                    TargetSite = ex.TargetSite?.ToString(),
                    HelpLink = ex.HelpLink,
                    StackTrace = ex.StackTrace,
                    ApplicationName = AppName
                });

                // Save changes
                await _context.SaveChangesAsync();

            } catch (Exception e)
            {
                // Log error to console
                Console.WriteLine($"An error occurred while logging error: {e.Message}");
            }
        }
    }
}
