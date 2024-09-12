using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace FrappeGanttJS.Blazor
{
    public class GanttOptions
    {
        [JsonPropertyName("header_height")]
        public int HeaderHeight { get; set; } = 65;
        [JsonPropertyName("column_width")]
        public int ColumnWidth { get; set; } = 30;
        public int Step { get; set; } = 24;
        [JsonPropertyName("view_modes")]
        public string[] ViewModes { get; set; } = Blazor.ViewModes.All;
        [JsonPropertyName("bar_height")]
        public int BarHeight { get; set; } = 30;
        [JsonPropertyName("bar_corner_radius")]
        public int BarCornerRadius { get; set; } = 3;
        [JsonPropertyName("arrow_curve")]
        public int ArrowCurve { get; set; } = 5;
        public int Padding { get; set; } = 18;
        [JsonPropertyName("view_mode")]
        public string ViewMode { get; set; } = Blazor.ViewModes.Day;
        [JsonPropertyName("date_format")]
        public string DateFormat { get; set; } = "YYYY-MM-DD";
        [JsonPropertyName("popup_trigger")]
        public string PopupTrigger { get; set; } = "click";
        [JsonPropertyName("show_expected_progress")]
        public bool ShowExpectedProgress { get; set; } = false;
        public ElementReference? Popup { get; set; } = null;
        public string Language { get; set; } = "en";
        [JsonPropertyName("readonly")]
        public bool ReadOnly { get; set; } = false;
        [JsonPropertyName("highlight_weekends")]
        public bool HighlightWeekends { get; set; } = true;
        [JsonPropertyName("scroll_to")]
        public string ScrollTo { get; set; } = "start";
        public string Lines { get; set; } = "both";
        [JsonPropertyName("auto_move_labels")]
        public bool AutoMoveLabels { get; set; } = true;
        [JsonPropertyName("today_buttons")]
        public bool TodayButtons { get; set; } = true;
        [JsonPropertyName("view_mode_selector")]
        public bool ViewModeSelector { get; set; } = false;
    }
}
