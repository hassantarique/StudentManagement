using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.API.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
