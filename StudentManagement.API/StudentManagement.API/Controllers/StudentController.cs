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
        public ActionResult InsertStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(new { message = "Invalid student data." });
            }

            var studentDA = new StudentDA();
            studentDA.InsertStudent(student);

            return Ok(new { message = "Student inserted successfully." });
        }


        [HttpPut("UpdateStudent")]
        public ActionResult UpdateStudent([FromBody] Student student)
        {
            if (student == null || student.ID <= 0)
            {
                return BadRequest(new { message = "Student ID is required for update." }); //Because IDs are not Assigned automatically.
            }

            var studentDA = new StudentDA();
            studentDA.UpdateStudent(student);

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
