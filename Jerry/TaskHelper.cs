using System.Linq;
using Windows.ApplicationModel.Background;

namespace Jerry
{
    public class TaskHelper
    {
        private const string TaskName = "updateTileTask";

        public static void RegisterBackgroundTask()
        {
            DeregisterTask();
            
            var builder = new BackgroundTaskBuilder
                {
                    Name = TaskName,
                    TaskEntryPoint = "Jerry.Background.BackgroundTask"
                };

            builder.SetTrigger(new SystemTrigger(SystemTriggerType.NetworkStateChange, false));
            builder.Register();
        }

        private static void DeregisterTask()
        {
            var task = BackgroundTaskRegistration.AllTasks.FirstOrDefault(t => t.Value.Name == TaskName);
            if (task.Value == null) return;

            task.Value.Unregister(false);
        }
    }
}