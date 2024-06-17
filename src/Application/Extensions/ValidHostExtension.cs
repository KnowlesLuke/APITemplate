using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ValidHostExtension
    {
        public static bool IsValid(this string validHostList, string requestHost)
        {
            if (requestHost == null || validHostList == null)
                return false;

            // If the valid host is *, return true
            if (validHostList == "*")
                return true;

            // Get hosts from comma separated string
            string[] validHosts = validHostList.Split(',');

            // Check if the http host matches any of the valid hosts
            foreach (string host in validHosts)
            {
                Regex regex = new(@"\^." + host.Trim() + ".*");

                if (regex.IsMatch(requestHost))
                    return true;
            }

            return false;
        }
    }
}
