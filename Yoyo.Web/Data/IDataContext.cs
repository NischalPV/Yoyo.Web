using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Models;

namespace Yoyo.Web.Data
{
    public interface IDataContext
    {
        /// <summary>
        /// Awaitable list of atheletes from Atheletes.json
        /// Similar functionality as DbContext
        /// </summary>
        /// <returns>List<Athelete></returns>
        Task<List<Athelete>> Atheletes();

        /// <summary>
        /// Awaitable list of fitness ratings from FitnessRatings.json
        /// Similar functionality as DbContext
        /// </summary>
        /// <returns>List<FitnessRating></returns>
        Task<List<FitnessRating>> FitnessRatings();
    }
}
