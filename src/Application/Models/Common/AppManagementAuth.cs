using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Common
{
    public class AppManagementAuth
    {
        /*
         * This class is used to store the app details from the database
         * It is invoked in the AppManagementService class when authenticating a request
         */

        public AppManagementAuth()
        {
            // Default constructor
        }

        public string Name { get; private set; }

        public string SecretKey { get; private set; }
    }
}
