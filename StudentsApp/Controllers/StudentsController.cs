using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Infrastructure;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsDataContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentRepo _repo;

        public StudentsController(StudentsDataContext context, IMapper mapper, IStudentRepo Repo)
        {
            _context = context;
            _mapper = mapper;
            _repo = Repo;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var student = await _repo.GetAll();
            var mappeditem = student.Select(x=> _mapper.Map<StudentDTO>(x));
            return View(mappeditem);



              //return _context.Students != null ? 
                          //View(await _context.Students.ToListAsync()) :
                        //  Problem("Entity set 'StudentsDataContext.Students'  is null.");
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Students == null)
                {
                    return NotFound(); 
                }

                var student = await _repo.GetByID(id);
                    //.FirstOrDefaultAsync(m => m.Id == id);
                var mappeditem = _mapper.Map<StudentDTO>(student); 

                if (mappeditem == null)
                {
                    return NotFound();
                }

                return View(mappeditem);
            }
            catch (Exception ex)
            {

                TempData["erroeMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RollNo,FamilyName,Address,Contact")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    TempData["successMessage"] = "Student created successfully";
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
            }
            catch (Exception ex)
            {

                TempData["erroeMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Students == null)
                {
                    return NotFound();
                }

                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Students/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RollNo,FamilyName,Address,Contact")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'StudentsDataContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}

//_mapper.Map<List<StudentDTO>>(student);
