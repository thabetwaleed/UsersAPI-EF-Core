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
            var posts = await _postService.Get<PostViewModel>();
            var PostsVM = _mapper.Map<List<Post>>(posts);


            if (posts == null)
                    return NotFound();
                return Ok( PostsVM);
            
            
        }

        [HttpGet("{id}")]
       // [Roles]
        public async Task<ActionResult<PostViewModel>> GetPost(int id)
        {
            var post =await _postService.GetId<PostViewModel>(id);
            var PostsVM = _mapper.Map<PostViewModel>(post);

            if (post == null)
                return NotFound();
            return Ok(PostsVM);
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

        [HttpPut]
        public ActionResult<PostViewModel> Update(PostViewModel post)
        {
            var model = _postService.Update(_mapper.Map<Post>(post));
            var PostsVM = _mapper.Map<PostViewModel>(model);

            return Ok(PostsVM); 
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
             await _postService.Delete<PostViewModel>(id);
            return Ok();
        }
    }
}
