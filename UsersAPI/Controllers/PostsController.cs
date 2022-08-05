using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UsersAPI.Fillters;
using UsersAPI.Model;
using UsersAPI.Repos;
using UsersAPI.ViewModel;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IMapper _mapper;
        INewPostRepo _postService;
        public  PostsController(INewPostRepo postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        //[Roles]
        public async Task<ActionResult<List<PostViewModel>>> GetAllPosts()
        {
            //throw new Exception("error");
            var userid = User.FindFirst(ClaimTypes.Sid)?.Value;
            var posts = await _postService.Get<PostViewModel>();
            var Myposts = posts.Where(a => a.UserId == int.Parse(userid));

            var PostsVM = _mapper.Map<List<Post>>(Myposts);


            if (posts == null)
                    return NotFound();
                return Ok( PostsVM);
            
            
        }

        [Authorize]
        [HttpGet("{id}")]
       // [Roles]
        public async Task<ActionResult<PostViewModel>> GetPost(int id)
        {
            try
            {
                var userid = User.FindFirst(ClaimTypes.Sid)?.Value;
                var post = await _postService.GetId<PostViewModel>(id);
                var PostsVM = _mapper.Map<PostViewModel>(post);

                if (post.UserId == int.Parse(userid))
                {
                    return Ok(PostsVM);
                }
                return NotFound();
            }
            catch(Exception e)
            {
                return NotFound("This id is invalid");
            }
         }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostViewModel>> Add([FromBody]PostViewModel post)
        {
            //get the id from token that currently (the user is authentecated and authorized)
            var userid = User.FindFirst(ClaimTypes.Sid)?.Value;
            post.UserId = int.Parse(userid);

            var model = await _postService.Add(_mapper.Map<Post>(post));
            var PostsVM = _mapper.Map<PostViewModel>(model);

            return Ok(PostsVM);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<PostViewModel>> Update(PostViewModel post)
        {
            try
            {
                var postmodel =await _postService.GetId<PostViewModel>(post.Id);
                var userid = User.FindFirst(ClaimTypes.Sid)?.Value;
 
                if (postmodel.UserId == int.Parse(userid))
                {
                    post.UserId = int.Parse(userid);
                    var model = _postService.Update(_mapper.Map<Post>(post));
                    var PostsVM = _mapper.Map<PostViewModel>(model);

                    return Ok("The post Updated successfully");
                }
                return NotFound("This id is invalid");
            }
            catch (Exception ex)
            {
                return BadRequest("Something error");
            }




             
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {

            try
            {
                var userid = User.FindFirst(ClaimTypes.Sid)?.Value;
                var post = await _postService.GetId<PostViewModel>(id);
                if (post.UserId==int.Parse(userid))
                {
                    await _postService.Delete<PostViewModel>(id);
                    return Ok("The post Deleted successfully");
                }
                return NotFound("This id is invalid");
            }
            catch(Exception ex)
            {
                return NotFound("This id is invalid");
            }
        }
    }
}
