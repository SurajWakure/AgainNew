using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20, Email = "john@example.com" },
            new Student { Id = 2, Name = "Jane Smith", Age = 22, Email = "jane@example.com" }
        };

        // GET: api/student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/student/1
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Email = updatedStudent.Email;

            return NoContent();
        }

        // DELETE: api/student/1
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }
    }
}
