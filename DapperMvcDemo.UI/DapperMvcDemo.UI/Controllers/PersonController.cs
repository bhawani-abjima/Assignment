using DapperMvcDemo.Data.Models.Domain;
using DapperMvcDemo.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperMvcDemo.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;
        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
            
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            return View();
        }
        public async Task<IActionResult> GetById(int id)
        {
            return View();
        }
        
        public async Task<IActionResult> DisplayAll()
        {
            var people = await _personRepo.GetAllAsync();
            return View(people);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _personRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }

    }
}
