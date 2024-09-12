namespace FrappeGanttJS.Blazor
{
    public class DateChangeEventArgs(GanttTaskData task, DateTime start, DateTime end)
    {
        public GanttTaskData Task { get; } = task;
        public DateTime Start { get; } = start;
        public DateTime End { get; } = end;
    }
}
