﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPWebAPI.Models;
using AutoMapper;
using ASPWebAPI.DTO;
using ASPWebAPI.Infrastructure;

namespace ASPWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsDataContext _context;
        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public StudentsController(StudentsDataContext context, IStudentRepo Repo, IMapper mapper)
        {
            _context = context;
            _repo = Repo;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetStudents()
        {
            try
            {
                var students = _repo.GetAll();
                return Ok(students.Select(_mapper.Map<StudentDTO>));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/Students/1
        [HttpGet("{id}")]
        public  ActionResult<Student> GetStudent(int id)
        {
            try
            {
                var student = _repo.GetByID(id);

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
