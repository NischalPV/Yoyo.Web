using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Data;
using Yoyo.Web.Interfaces;
using Yoyo.Web.Models;

namespace Yoyo.Web.Repository
{
    public class AtheleteRepository : IAtheleteRepository
    {
        protected IDataContext _context;

        public AtheleteRepository(IDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get an athelete by specified Id
        /// </summary>
        /// <param name="id">Id of the athelete</param>
        /// <returns>Athelete</returns>
        public async Task<Athelete> GetAtheleteById(int id)
        {
            return (await ListAllAtheletes()).Where(x => x.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Lists all the athelete from context
        /// </summary>
        /// <returns>List<Athelete></returns>
        public async Task<List<Athelete>> ListAllAtheletes()
        {
            return await _context.Atheletes();
        }


        /// <summary>
        /// Set the status of any athelete specified by Id. Useful if we want to save the athelete status to database.
        /// </summary>
        /// <param name="id">Id of the athelete for which status is to be set</param>
        /// <param name="status">Status that is to be set. e.g. "Warned"</param>
        /// <param name="score">Score that has to be set in Level-Shuttle format. e.g. "5-1"</param>
        /// <returns>AtheleteStatus</returns>
        public async Task<AtheleteStatus> SetAtheleteStatus(int id, string status, string score)
        {
            var athelete = await GetAtheleteById(id);

            return new AtheleteStatus()
            {
                AtheleteId = id,
                Score = score,
                Status = status
            };

        }
    }
}
