using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp2.Server.Controllers
{
    public class UserController : Controller
    {
        IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult LoginUser([FromBody] User user)
        {
            return Json(_user.Login(user));
        }
        [HttpGet]
        [Route("api/user/getall")]
        public IEnumerable<User> GetUsersActive()
        {
            return _user.GetAllActiveUsers();
        }
    }
}
