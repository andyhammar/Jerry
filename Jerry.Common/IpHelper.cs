using System.Linq;
using System.Text.RegularExpressions;
using Windows.Networking.Connectivity;

namespace Jerry.Common
{
    public class IpHelper
    {
        public static string GetIp()
        {
            var hosts = NetworkInformation.GetHostNames();
            var ipHosts = hosts.Where(x => IsIp(x.DisplayName));
            var realIpHosts = ipHosts.Where(x => !x.DisplayName.StartsWith("169.") && !x.DisplayName.StartsWith("0."));

            var host = realIpHosts.FirstOrDefault();

            return host != null ? host.DisplayName : "Could not find an IP address, are you connected?";
        }

        private static bool IsIp(string displayName)
        {
            const string regex = @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$";
            return Regex.IsMatch(displayName, regex);
        }
    }

}
