using Microsoft.AspNetCore.Mvc;
using StudentManagement.ADODAL;
using StudentManagement.DomainObjects;

namespace StudentManagement.API.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet("GetAllStudents")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> students = new StudentDA().GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudentById")]
        public ActionResult<Student> GetStudentById(int StudentID)
        {
            Student student = new StudentDA().GetStudentByID(StudentID);
            return Ok(student);
        }

        [HttpPost("InsertStudent")]
        public ActionResult<Student> InsertStudent(
            [FromQuery] string name,
            [FromQuery] int genderID,
            [FromQuery] DateTime dateOfBirth,
            [FromQuery] decimal height,
            [FromQuery] int weight)
        {
            var studentDA = new StudentDA();
            studentDA.InsertStudent(name, genderID, dateOfBirth, height, weight);

            return Ok(new { message = "Student inserted successfully." });
        }

        [HttpPut("UpdateStudent")]
        public ActionResult UpdateStudent(
            [FromQuery] int studentId,
            [FromQuery] string name,
            [FromQuery] int genderID,
            [FromQuery] DateTime dateOfBirth,
            [FromQuery] decimal height,
            [FromQuery] int weight)
        {
            var studentDA = new StudentDA();
            studentDA.UpdateStudent(studentId, name, genderID, dateOfBirth, height, weight);

            return Ok(new { message = "Student updated successfully." });
        }

        [HttpDelete("DeleteStudent")]
        public ActionResult DeleteStudent([FromQuery] int studentId)
        {
            var studentDA = new StudentDA();
            studentDA.DeleteStudent(studentId);

            return Ok(new { message = $"Student deleted successfully." });
        }


    }
}
