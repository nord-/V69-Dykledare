using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace V69_Dykledare.Models
{
    public class Buddies
    {
        public ObservableCollection<Diver> Divers { get; set; }

        public int MaxTime { get; set; }
        public int MaxDepth { get; set; }
        public DateTime? DiveStart { get; set; }
        public DateTime? DiveEnd { get; set; }

        public string FirstDiver => Divers.FirstOrDefault()?.Name;
        public string BuddiesList => string.Join(", ", Divers.Select(d => d.Name));
        public string TimeAndDepth => $"{MaxDepth}m / {MaxTime} min";
        public DateTime? PredictedDiveEnd => DiveStart?.AddMinutes(MaxTime);

        private TimeSpan? TimeRemainingTimeSpan => PredictedDiveEnd.HasValue ? PredictedDiveEnd - DateTime.Now : null;
        public string TimeRemaining => TimeRemainingTimeSpan.HasValue ? $"{(int)TimeRemainingTimeSpan.Value.TotalMinutes:D2}:{TimeRemainingTimeSpan.Value.Seconds:D2}" : "";
    }
}