using Jerry.Common;
using Windows.ApplicationModel.Background;

namespace Jerry.Background
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
