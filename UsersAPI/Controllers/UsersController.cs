using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UsersAPI.Model;
using UsersAPI.Repos;
using AutoMapper;
using UsersAPI.ViewModel;
using UsersAPI.Fillters;
using Microsoft.AspNetCore.Authorization;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        INewUserRepo _userService;
        IMapper _mapper;
        public UsersController(INewUserRepo service,IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        //[Roles]
        public async Task<ActionResult<List<UserViewModel>>> GetAllUsers()//use IEnumerable or List
        {
            
                var users =await _userService.Get<UserViewModel>();
                var UsersVM=_mapper.Map <List<UserViewModel>>(users);            
                if (users == null)
                 return NotFound();
                return Ok(UsersVM);
                

        }

        [HttpGet("{id}")]
        [Roles]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await _userService.GetId<UserViewModel>(id);
            var UsersVM = _mapper.Map<UserViewModel>(user);
            if (user == null)
                return NotFound();
            return Ok(UsersVM);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Add(UserViewModel user)
        {
            var model=await _userService.Add(_mapper.Map<User>(user));
            var UsersVM = _mapper.Map<UserViewModel>(model);

            return Ok(UsersVM);
        }

        [HttpPut]
        public ActionResult<UserViewModel> Update(UserViewModel user)
        {
            var model=_userService.Update(_mapper.Map<User>(user));
            var UsersVM = _mapper.Map<List<UserViewModel>>(model);

            return Ok(UsersVM);
        }

        [HttpDelete]
        public async Task<ActionResult<UserViewModel>> DeleteUser(int id)
        {
           await _userService.Delete<UserViewModel>(id);
 
            return Ok();
        }
    }
}
