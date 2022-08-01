using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult<List<PostViewModel>>> GetAllPosts()
        {
            //throw new Exception("error");
             
                var posts = await _postService.Get();
            var PostsVM = _mapper.Map<List<PostViewModel>>(posts);


            if (posts == null)
                    return NotFound();
                return Ok( PostsVM);
            
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostViewModel>> GetPost(int id)
        {
            var post =await _postService.GetId(id);
            var PostsVM = _mapper.Map<PostViewModel>(post);

            if (post == null)
                return NotFound();
            return Ok(PostsVM);
        }

        [HttpPost]
        public async Task<ActionResult<PostViewModel>> Add([FromBody]Post post)
        {
            var model = await _postService.Add(post);
            var PostsVM = _mapper.Map<PostViewModel>(model);

            return Ok(PostsVM);
        }

        [HttpPut]
        public ActionResult<PostViewModel> Update(Post post)
        {
            var model = _postService.Update(post);
            var PostsVM = _mapper.Map<PostViewModel>(model);

            return Ok(PostsVM); 
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
             await _postService.Delete(id);
            return Ok();
        }
    }
}
