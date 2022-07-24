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
        IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetPostsList();
            if (posts == null)
                return NotFound();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _postService.GetPostById(id);
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
            var model = _postService.DeletePost(id);
            return Ok(model);
        }
    }
}
