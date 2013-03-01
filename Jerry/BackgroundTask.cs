using Windows.ApplicationModel.Background;

namespace Jerry
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var ip = IpHelper.GetIp();
            TileHelper.UpdateTile(ip);
        }
    }
}
