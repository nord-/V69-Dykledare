using System;
using System.Collections.ObjectModel;
using System.Linq;
using PropertyChanged;
using Xamarin.Forms;

namespace V69_Dykledare.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Buddy
    {
        public ObservableCollection<Diver> Divers { get; set; }

        public int MaxTime { get; set; }
        public int MaxDepth { get; set; }
        public DateTime? DiveStart { get; set; }
        public DateTime? DiveEnd { get; set; }
        public int Index { get; set; }
        [AlsoNotifyFor(nameof(TimeRemaining), nameof(TimeOvertimeColor))]
        public DateTime CurrentTime { get; set; }

        public string FirstDiver => Divers.FirstOrDefault()?.Name;
        public string BuddiesList => string.Join(", ", Divers.Select(d => d.Name));
        public string TimeAndDepth => $"{MaxDepth}m / {MaxTime} min";
        public DateTime? PredictedDiveEnd => DiveStart?.AddMinutes(MaxTime);
        public bool DiveActive => DiveStart.HasValue && !DiveEnd.HasValue;
        public bool DiveOvertime => (TimeRemainingTimeSpan?.TotalSeconds ?? 0) < 0;

        private TimeSpan? TimeRemainingTimeSpan
        {
            get
            {
                if (DiveEnd.HasValue)
                    return DiveEnd.Value - DiveStart.Value;

                return PredictedDiveEnd.HasValue ? PredictedDiveEnd - DateTime.Now : null;
            }
        }

        public string TimeRemaining
        {
            get
            {
                if (DiveActive)
                    return TimeRemainingTimeSpan.HasValue ? $"{(DiveOvertime ? "-":"")}{(int)Math.Abs(TimeRemainingTimeSpan.Value.TotalMinutes):D2}:{Math.Abs(TimeRemainingTimeSpan.Value.Seconds):D2}" : "";

                return !DiveStart.HasValue ? "" : $"{Math.Ceiling((DiveEnd.Value - DiveStart.Value).TotalMinutes)} min";
            }
        }

        public Color ButtonBackgroundColor => DiveActive ? Color.DarkRed : Color.Green;
        public string ButtonText => DiveActive ? "Stopp" : "Start";
        public Color TimeOvertimeColor => DiveOvertime ? Color.DarkRed : Color.Default;
    }
}