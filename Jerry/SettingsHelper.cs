using System;
using Windows.UI.ApplicationSettings;

namespace Jerry
{
    public static class SettingsHelper
    {
        public static void AddSettingsCommands(SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Clear();

            var privacyPref = new SettingsCommand("privacyPref", "Privacy Policy", (uiCommand) =>
                {
                    Windows.System.Launcher.LaunchUriAsync(new Uri("http://ahamprivacypolicy.azurewebsites.net/"));
                });

            args.Request.ApplicationCommands.Add(privacyPref);
        }

    }
}