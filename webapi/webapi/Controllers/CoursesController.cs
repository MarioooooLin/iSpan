﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using webapi.DTO;
using webapi.Models;

namespace webapi.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly TriangleContext _context;

        public CoursesController(TriangleContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<CourseDetailDTO>> GetCourse()
        {
            var result = _context.Course.Join(_context.Teacher, x => x.TeacherId, y => y.TeacherId, (cou, tea) => new CourseDetailDTO
            {
                CourseId = cou.CourseId,
                CourseName = cou.CourseName,
                Price = cou.Price,
                TeacherName = tea.Name,
                TeacherImg = tea.img,
                Intro = tea.Intro,
                CourseReqire = cou.CourseReqire,
                CourseIntro = cou.CourseIntro,
                CourseLength = cou.CourseLength,
                CourseImg = cou.img,

            });
            return result;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<CourseDetailDTO>> GetCourse(int id)
        {
            var result = _context.Course.Join(_context.Teacher, x => x.TeacherId, y => y.TeacherId, (cou, tea) => new CourseDetailDTO
            {
                CourseId = cou.CourseId,
                CourseName = cou.CourseName,
                Price = cou.Price,
                TeacherName = tea.Name,
                TeacherImg = tea.img,
                Intro = tea.Intro,
                CourseReqire = cou.CourseReqire,
                CourseIntro = cou.CourseIntro,
                CourseLength = cou.CourseLength,
                CourseImg = cou.img,

            }).Where(x=>x.CourseId==id);

            return result;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
