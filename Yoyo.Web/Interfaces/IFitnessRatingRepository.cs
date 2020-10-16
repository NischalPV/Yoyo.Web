using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Models;
using Yoyo.Web.Models.ViewModels;

namespace Yoyo.Web.Interfaces
{
    public interface IFitnessRatingRepository
    {
        /// <summary>
        /// Awaitable List of all fitness ratings returned from DataContext
        /// </summary>
        /// <returns>List<FitnessRatingViewModel></returns>
        Task<List<FitnessRatingViewModel>> ListAllFitnessRatings();

        /// <summary>
        /// Finds next shuttle based on current time
        /// </summary>
        /// <param name="currentTime">Current time at the timer.</param>
        /// <returns>FitnessRatingViewModel</returns>
        Task<FitnessRatingViewModel> GetNextFitnessRating(TimeSpan currentTime);

        /// <summary>
        /// Finds current shuttle based on current time
        /// </summary>
        /// <param name="currentTime">Current time at the timer.</param>
        /// <returns>FitnessRatingViewModel</returns>
        Task<FitnessRatingViewModel> GetCurrentFitnessRating(TimeSpan currentTime);
    }
}
