using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Models;

namespace Yoyo.Web.Interfaces
{
    /// <summary>
    /// Public interface of Athelete repository
    /// </summary>
    public interface IAtheleteRepository
    {
        /// <summary>
        /// Awaitable List of all atheletes returned from DataContext
        /// </summary>
        /// <returns>List<Athelete></returns>
        Task<List<Athelete>> ListAllAtheletes();

        /// <summary>
        /// Get Athelete object specified by Id
        /// </summary>
        /// <param name="id">Id of the athelete</param>
        /// <returns>Awaitable object of Athelete</returns>
        Task<Athelete> GetAtheleteById(int id);
        
        /// <summary>
        /// Set the status of athelete specified by Id
        /// </summary>
        /// <param name="id">Id of the Athelete for which the status has to be set. Useful when saving to database.</param>
        /// <param name="status">Status that has to be set. e.g. "Warned", "Stopped"</param>
        /// <param name="score">Score in format Level-Shuttle. e.g. 11-3.</param>
        /// <returns></returns>
        Task<AtheleteStatus> SetAtheleteStatus(int id, string status, string score);
    }
}
