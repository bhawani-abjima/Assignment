using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentsDetails.Infrastructure;
using StudentsDetails.Models;

namespace StudentsDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepo _repo;
        public HomeController(ILogger<HomeController> logger ,IStudentRepo Repo)
        {
            _logger = logger;
            _repo = Repo;
        }
        public IActionResult Index()
        {

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
    }
}