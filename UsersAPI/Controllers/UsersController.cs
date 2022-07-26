using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UsersAPI.Model;
using UsersAPI.Repos;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        INewUserRepo _userService;
        public UsersController(INewUserRepo service)
        {
            _userService = service;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users=_userService.Get();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetId(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var model=_userService.Add(user);
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var model=_userService.Update(user);
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
