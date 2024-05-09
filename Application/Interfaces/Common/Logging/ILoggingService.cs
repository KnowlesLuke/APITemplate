using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common.Logging
{
    public interface ILoggingService
    {
        public Task LogError(string process, string message, Exception ex);
    }
}
