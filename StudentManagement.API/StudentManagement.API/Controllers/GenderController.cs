using Microsoft.AspNetCore.Mvc;
using StudentManagement.ADODAL;
using StudentManagement.API.Repositories;
using StudentManagement.DomainObjects;

namespace StudentManagement.API.Controllers
{
    [Route("api/Gender")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[TypeFilter(typeof(ApiKeyAttribute))]

    public class GenderController : Controller
    {
        [HttpGet("GetAllGenders")]
        public ActionResult<IEnumerable<Gender>> GetAllGenders()
        {
            List<Gender> genders = new GenderDA().GetAllGenders();
            return Ok(genders);
        }

        [HttpGet("GetGenderById")]
        public ActionResult<Gender> GetGenderById(int GenderID)
        {
            Gender gender = new GenderDA().GetGenderByID(GenderID);
            return Ok(gender);
        }
    }
}
