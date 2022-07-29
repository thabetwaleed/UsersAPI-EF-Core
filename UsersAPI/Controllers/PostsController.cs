using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Model;
using UsersAPI.Repos;
namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        INewPostRepo _postService;
        public PostsController(INewPostRepo postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAllPosts([FromHeader]string Role)
        {
            //throw new Exception("error");
            if (Role=="Admin")
            {
                var posts = _postService.Get();
                if (posts == null)
                    return NotFound();
                return Ok(posts);
            }
            else
                return BadRequest();
            
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _postService.GetId(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Post post)
        {
            var model = _postService.Add(post);
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Update(Post post)
        {
            var model = _postService.Update(post);
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
              _postService.Delete(id);
            return Ok();
        }
    }
}
