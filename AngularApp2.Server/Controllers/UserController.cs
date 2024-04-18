using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Models;
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
        [Route("api/registration")]
        public IActionResult Registration([FromBody] User newUser)
        {
            return Json(_user.Registration(newUser));
        }
    }
}
