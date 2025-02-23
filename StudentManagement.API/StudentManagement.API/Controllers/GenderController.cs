using Microsoft.AspNetCore.Mvc;
using StudentManagement.ADODAL;
using StudentManagement.DomainObjects;

namespace StudentManagement.API.Controllers
{
    [Route("api/Gender")]
    [ApiController]
    public class GenderController : Controller
    {
        [HttpGet("AllGenders")]
        public ActionResult<IEnumerable<Gender>> GetAllGenders()
        {
            List<Gender> genders = new GenderDA().GetAllGenders();
            return Ok(genders);
        }
    }
}
