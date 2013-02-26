using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Jerry.Common;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Jerry
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Jerry.Common.LayoutAwarePage
    {   
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var ip = GetIp();
            ipText.Text = ip;
        }

        private string GetIp()
        {
            var hosts = NetworkInformation.GetHostNames();
            var ipHosts = hosts.Where(x => IsIp(x.DisplayName));
            var realIpHosts = ipHosts.Where(x => !x.DisplayName.StartsWith("169.") && !x.DisplayName.StartsWith("0."));

            var host = realIpHosts.FirstOrDefault();

            return host != null ? host.DisplayName : "Could not find an IP address, are you connected?";
        }

        private bool IsIp(string displayName)
        {
            var regex = @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$";
            return Regex.IsMatch(displayName, regex);
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
