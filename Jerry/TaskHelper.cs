using System.Linq;
using Windows.ApplicationModel.Background;

namespace Jerry
{
    public class TaskHelper
    {
        private const string TaskName = "task";

        public static void RegisterBackgroundTask()
        {
            if (IsTaskRegistered()) return;

            var builder = new BackgroundTaskBuilder
                {
                    Name = TaskName, 
                    TaskEntryPoint = "Jerry.BackgroundTask"
                };

            builder.SetTrigger(new SystemTrigger(SystemTriggerType.NetworkStateChange, false));
        }

        private static bool IsTaskRegistered()
        {
            return BackgroundTaskRegistration.AllTasks.Any(task => task.Value.Name == TaskName);
        }
    }
}