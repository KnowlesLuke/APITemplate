using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Common
{
    public class AppDetails
    {
        /*
         * This class is mapped to the ApplicationDetails section in the appsettings.json file.
         * It is mapped in the program.cs file
         * This allows it to be injected into different services
         * 
        */

        public string Name { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }
    }
}
