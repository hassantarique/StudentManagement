using Microsoft.AspNetCore.Mvc;

namespace Globomatics.Web.Controllers
{
    [Route("{region:region}/user/{username:regex(^[a-zA-Z0-9_-]{3,16}$)}")]
    public class UserProfileController : Controller
    {
        [HttpGet]
        public IActionResult ViewProfile(string region, string username)
        {
            ViewBag.Region = region;
            ViewBag.Username = username;
            return View();
        }
    }

    //Example Urls that work:
    //http://localhost:5000/eu/user/johndoe
    //http://localhost:5000/us/user/jane_doe123
    //http://localhost:5000/asia/user/ViewProfile

    //Wont work
    //"http://localhost:5000//eu/user/$invalidName!"
}
