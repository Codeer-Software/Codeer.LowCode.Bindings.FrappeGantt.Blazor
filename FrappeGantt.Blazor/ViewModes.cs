namespace FrappeGanttJS.Blazor
{
    public class ViewModes
    {
        public enum Enum
        {
            Hour,
            QuarterDay,
            HalfDay,
            Day,
            Week,
            Month,
            Year,
        }

        public const string Hour = "Hour";
        public const string QuarterDay = "Quarter Day";
        public const string HalfDay = "Half Day";
        public const string Day = "Day";
        public const string Week = "Week";
        public const string Month = "Month";
        public const string Year = "Year";

        public static readonly string[] All = [Hour, QuarterDay, HalfDay, Day, Week, Month, Year];

        public static string AsInteropValue(Enum @enum) => @enum switch
        {
            Enum.Hour => Hour,
            Enum.QuarterDay => QuarterDay,
            Enum.HalfDay => HalfDay,
            Enum.Day => Day,
            Enum.Week => Week,
            Enum.Month => Month,
            Enum.Year => Year,
            _ => throw new ArgumentOutOfRangeException(nameof(@enum), @enum, null)
        };

        public static Enum AsEnum(string value) => value switch
        {
            Hour => Enum.Hour,
            QuarterDay => Enum.QuarterDay,
            HalfDay => Enum.HalfDay,
            Day => Enum.Day,
            Week => Enum.Week,
            Month => Enum.Month,
            Year => Enum.Year,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}
