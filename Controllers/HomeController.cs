using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using SearchMovies.DAL;
using SearchMovies.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace SearchMovies.Controllers
{
    /// <summary>
    /// Home Controller class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Home controller constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>View</returns>
       public IActionResult Index()
       {
            return View();
       }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View - Index or Error</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.MovieSearch model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataAccess dataAccess = new DataAccess();
                    model.ListMovies = dataAccess.GetMovies(model);
                    model.PageCount = model.ListMovies.Count();

                    return MovieResults(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError("There has been an error " + ex);
                    return View("Error");
                }
            }

            return View("Index", model);
        }

        /// <summary>
        /// Movie Results
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult MovieResults(MovieSearch model)
        {
            return View("MovieResults", model);
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Privacy()
        {
            //TODO Requires completion

            return View();
        }
    }
}
