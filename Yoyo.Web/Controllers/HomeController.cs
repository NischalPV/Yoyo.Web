using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yoyo.Web.Data;
using Yoyo.Web.Interfaces;
using Yoyo.Web.Models;

namespace Yoyo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IAtheleteRepository _atheleteRepository;  // Initialize Athelete repository
        protected IFitnessRatingRepository _fitnessRatingRepository;    // Initialize FitnessRatings repository

        //private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, IAtheleteRepository atheleteRepository, IFitnessRatingRepository fitnessRatingRepository)
        {
            _logger = logger;
            _atheleteRepository = atheleteRepository;
            _fitnessRatingRepository = fitnessRatingRepository;
            //_context = context;
        }

        /// <summary>
        /// Displays application home page
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var atheletes = await _atheleteRepository.ListAllAtheletes();
            ViewData["Athelets"] = atheletes;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region APIs


        /// <summary>
        /// API to get the list of all Fitness ratings
        /// </summary>
        /// <returns>List<FitnessRating></returns>
        [HttpGet]
        [Route("api/fitnessratings")]
        [Produces(typeof(List<FitnessRating>))]
        public async Task<IActionResult> GetFitnessRatings()
        {
            return Ok(await _fitnessRatingRepository.ListAllFitnessRatings());
        }

        /// <summary>
        /// API to get next Fitness Rating based on current time.
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns>FitnessRatingViewModel</returns>
        [HttpGet]
        [Route("api/fitnessratings/next/{currentTime}")]
        public async Task<IActionResult> GetFitnessNextRating(string currentTime)
        {
            var currTime = TimeSpan.Parse(currentTime);
            return Ok(await _fitnessRatingRepository.GetNextFitnessRating(currTime));
        }

        #endregion
    }
}
