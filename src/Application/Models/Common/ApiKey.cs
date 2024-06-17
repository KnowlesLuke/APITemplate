using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinimalLibrary.Models.ApiKey
{
    public class ApiKey
    {
        public const string APIKeyHeaderName = "X-API-Key";
        public const string Auth = "AuthToken";
        public const string AppGuid = "AppGuid";
        public const string TimeEpoch = "TimeEpoch";

        public string Key { get; private set; }

        public int Timeout { get; private set; }

        public string ApplicationGuid { get; private set; }

        public string AuthToken { get; private set; }

        public ApiKey(string key, string authToken, int timeout, string applicationGuid)
        {
            Key = key;
            Timeout = timeout;
            AuthToken = authToken;
            ApplicationGuid = applicationGuid;
        }
    }
}
