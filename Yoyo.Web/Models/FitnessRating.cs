using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoyo.Web.Models
{
    /// <summary>
    /// Model representing properties to a single Fitness rating or shuttle from FitnessRatings.json file
    /// Note how it is inherited from BaseEntity with Id as string data type.
    /// </summary>
    public class FitnessRating : BaseEntity<string>
    {
        public string AccumulatedShuttleDistance { get; set; }
        public string SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public string LevelTime { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
        public string ApproxVo2Max { get; set; }

        public FitnessRating()
        {
            Id = Guid.NewGuid().ToString(); // Necessary to fit the model with BaseEntity
        }
    }
}
