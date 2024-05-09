using Application.Interfaces.Common.Logging;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
    public class LoggingService : ILoggingService
    {
        private readonly ApplicationManagementDbContext _context;

        public LoggingService(ApplicationManagementDbContext context)
        {
            _context = context;
        }

        public Task LogError(string process, string message, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
