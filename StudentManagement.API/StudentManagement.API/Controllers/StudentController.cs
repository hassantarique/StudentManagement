using Microsoft.AspNetCore.Mvc;
using StudentManagement.ADODAL;
using StudentManagement.DomainObjects;

namespace StudentManagement.API.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet("AllStudents")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> students = new StudentDA().GetAllStudents();
            return Ok(students);
        }

        [HttpGet("StudentById")]
        public ActionResult<Student> GetStudentById(int StudentID)
        {
            Student student = new StudentDA().GetStudentByID(StudentID);
            return Ok(student);
        }
    }
}
