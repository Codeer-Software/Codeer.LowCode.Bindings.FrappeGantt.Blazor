namespace FrappeGanttJS.Blazor
{
    public class ProgressChangeEventArgs(GanttTaskData task, double progress)
    {
        public GanttTaskData Task { get; } = task;
        public double Progress { get; } = progress;
    }
}
