using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Project3_Franko_Fister.Models;
using System.Threading.Tasks;

/// <summary>
/// Controller for handling home related requests.
/// </summary>
namespace Project3_Franko_Fister.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles the Index view request.
        /// </summary>
        /// <returns>The Index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles the News view request.
        /// </summary>
        /// <returns>The News view with the NewsModel.</returns>
        public async Task<IActionResult> News()
        {
            return View(await NewsModel.GetViewModelAsync());
        }

        /// <summary>
        /// Handles the About view request.
        /// </summary>
        /// <returns>The About view with the AboutModel.</returns>
        public async Task<IActionResult> About()
        {
            return View(await AboutModel.GetModelAsync());
        }

        /// <summary>
        /// Handles the Degrees view request.
        /// </summary>
        /// <returns>The Degrees view with the DegreesViewModel.</returns>
        public async Task<IActionResult> Degrees()
        {
            var degrees = await DegreesService.GetDegreesAsync();
            var viewModel = new DegreesViewModel
            {
                Degrees = degrees
            };
            return View(viewModel);
        }

        /// <summary>
        /// Handles the Faculty view request.
        /// </summary>
        /// <returns>The Faculty view with the FacultyViewModel.</returns>
        public async Task<IActionResult> Faculty()
        {
            var faculty = await FacultyService.GetFacultyAsync();
            var viewModel = new FacultyViewModel
            {
                Faculty = faculty
            };
            return View(viewModel);
        }

        /// <summary>
        /// Handles the Employment view request.
        /// </summary>
        /// <returns>The Employment view with the EmploymentViewModel.</returns>
        public async Task<IActionResult> Employment()
        {
            var employmentData = await EmploymentModel.GetEmploymentAsync();
            var viewModel = new EmploymentViewModel
            {
                EmploymentData = employmentData
            };
            return View(viewModel);
        }

        /// <summary>
        /// Handles the Error view request.
        /// </summary>
        /// <returns>The Error view with the ErrorViewModel.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}