using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoyo.Web.Models.ViewModels
{
    /// <summary>
    /// Viewmodel to parse string values from json file to their respective data types.
    /// </summary>
    public class FitnessRatingViewModel
    {
        public int AccumulatedShuttleDistance => Int32.Parse(this.FitnessRating.AccumulatedShuttleDistance);
        public int SpeedLevel => Int32.Parse(this.FitnessRating.SpeedLevel);
        public int ShuttleNo => Int32.Parse(this.FitnessRating.ShuttleNo);
        public float Speed => float.Parse(this.FitnessRating.Speed);
        public float LevelTime => float.Parse(this.FitnessRating.LevelTime);
        public TimeSpan CommulativeTime => TimeSpan.Parse($"00:{this.FitnessRating.CommulativeTime}");
        public TimeSpan StartTime => TimeSpan.Parse($"00:{this.FitnessRating.StartTime}");
        public float ApproxVo2Max => float.Parse(this.FitnessRating.ApproxVo2Max);

        public FitnessRating FitnessRating { get; set; }
    }
}
