using Microsoft.AspNetCore.Mvc;
using StudentMangement.Models;
using StudentMangement.Services;

namespace StudentMangement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentServices;

        public StudentController(IConfiguration configuration, IStudentService studentService)
        {
            _configuration = configuration;
            _studentServices = studentService;
        }

        public IActionResult Index()
        {
            StudentVM model=new StudentVM();
            model.StudentsList = _studentServices.GetStudentList().ToList();
            return View(model);
        }
    }
}
