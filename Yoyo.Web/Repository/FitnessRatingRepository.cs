using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Data;
using Yoyo.Web.Interfaces;
using Yoyo.Web.Models;
using Yoyo.Web.Models.ViewModels;

namespace Yoyo.Web.Repository
{
    public class FitnessRatingRepository : IFitnessRatingRepository
    {
        protected IDataContext _context;

        public FitnessRatingRepository(IDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get current Fitness Rating or shuttle based on current time value.
        /// </summary>
        /// <param name="currentTime">Current time elapsed at the timer</param>
        /// <returns>FitnessRatingViewModel</returns>
        public async Task<FitnessRatingViewModel> GetCurrentFitnessRating(TimeSpan currentTime)
        {
            var nextFitnessRating = await GetNextFitnessRating(currentTime);    // First get next fitness rating
            var previousFitnessRating = (await ListAllFitnessRatings()).OrderByDescending(x => x.StartTime).Where(x => x.StartTime < currentTime).FirstOrDefault(); // Then get all the fitness ratings that has elapsed, order by descending and get top shuttle

            var currentFitnessRating = (await ListAllFitnessRatings()).Where(x => x.StartTime > previousFitnessRating.StartTime && x.StartTime <= nextFitnessRating.StartTime).FirstOrDefault(); // Get the first shuttle having start time in between next and previous shuttles.

            return currentFitnessRating;

        }

        /// <summary>
        /// Gets the next shuttle based on the time elapsed.
        /// </summary>
        /// <param name="currentTime">Time elapsed in the timer.</param>
        /// <returns>FitnessRatingViewModel</returns>
        public async Task<FitnessRatingViewModel> GetNextFitnessRating(TimeSpan currentTime)
        {
            var fitnessRatings = await ListAllFitnessRatings(); // get list of all the shuttles or fitness ratings.

            return fitnessRatings.Where(x => x.StartTime >= currentTime).FirstOrDefault();  // get first shuttle whose start time is equal or greater than time elapsed.

        }

        /// <summary>
        /// Get the list of all the fitness ratings from DataContext and convert them to FitnessRatingViewModel objects.
        /// </summary>
        /// <returns>List<FitnessRatingViewModel></returns>
        public async Task<List<FitnessRatingViewModel>> ListAllFitnessRatings()
        {
            var rawFitnessRatings = await _context.FitnessRatings();    // Get raw fitnessrating or shuttle objects from DataContext
            List<FitnessRatingViewModel> fitnessRatingViewModels = new List<FitnessRatingViewModel>();

            // Convert the each object to FitnessRatingViewModel
            rawFitnessRatings.ForEach(x => fitnessRatingViewModels.Add(
                new FitnessRatingViewModel
                {
                    FitnessRating = x
                }
                ));

            // Return generated list of FitnessRatingViewModel
            return fitnessRatingViewModels.OrderBy(x => x.StartTime).ToList();
        }
    }
}
