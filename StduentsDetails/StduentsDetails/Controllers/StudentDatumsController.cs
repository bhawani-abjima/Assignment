using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsDetails.Entities;
using StudentsDetails.Infrastructure;
using StudentsDetails.Models;
using StudentDetails = StudentsDetails.Entities.StudentDetails;

namespace StudentsDetails.Controllers
{
    public class StudentDatumsController : Controller
    {
        private readonly StudentDetailsContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentRepo _repo;
        public StudentDatumsController(StudentDetailsContext context ,IMapper mapper,IStudentRepo Repo)
        {
            _context = context;
            _mapper = mapper;   
            _repo = Repo;
        }

        // GET: StudentDatums
        public async Task<IActionResult> Index()
        {
            var student = await _repo.GetAll();
            var gk=student.Select(x=>_mapper.Map<StudentDetails>(x));
            return View(gk);


             // return _context.StudentData != null ? 
                //          View(await _context.StudentData.ToListAsync()) :
                  //        Problem("Entity set 'StudentDetailsContext.StudentData'  is null.");
        }

        // GET: StudentDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentData == null)
            {
                return NotFound();
            }

            var studentDatum = await _context.StudentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDatum == null)
            {
                return NotFound();
            }

            return View(studentDatum);
        }

        // GET: StudentDatums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RollNo,FamilyName,Address,Contact")] Models.StudentDatum studentDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDatum);
        }

        // GET: StudentDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentData == null)
            {
                return NotFound();
            }

            var studentDatum = await _context.StudentData.FindAsync(id);
            if (studentDatum == null)
            {
                return NotFound();
            }
            return View(studentDatum);
        }

        // POST: StudentDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RollNo,FamilyName,Address,Contact")] Models.StudentDatum studentDatum)
        {
            if (id != studentDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDatumExists(studentDatum.Id))
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
            return View(studentDatum);
        }

        // GET: StudentDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentData == null)
            {
                return NotFound();
            }

            var studentDatum = await _context.StudentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDatum == null)
            {
                return NotFound();
            }

            return View(studentDatum);
        }

        // POST: StudentDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentData == null)
            {
                return Problem("Entity set 'StudentDetailsContext.StudentData'  is null.");
            }
            var studentDatum = await _context.StudentData.FindAsync(id);
            if (studentDatum != null)
            {
                _context.StudentData.Remove(studentDatum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDatumExists(int id)
        {
          return (_context.StudentData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
