using UsersAPI.Model;
using UsersAPI.ViewModels;
namespace UsersAPI.Repos
{
    public class PostRepos:IPostService
    {
        private UserContext _context;
        public PostRepos(UserContext context)
        {
            _context = context;
        }

        public List<Post> GetPostsList()
        {
            List<Post> PostsList;
            try
            {
                PostsList = _context.Set<Post>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return PostsList;
        }


        public Post GetPostById(int Id)
        {
            Post post;
             
                post = _context.Find<Post>(Id);
            
             
            return post;
        }

        public ResponseModel Add(Post post)
        {
            ResponseModel result = new ResponseModel();
            _context.Add<Post>(post);
            result.IsSuccess = true;
            _context.SaveChanges();
            return result;

        }

        public ResponseModel Update(Post post)
        {
            ResponseModel model = new ResponseModel();
            Post _temp = GetPostById(post.Id);
            _temp.Title = post.Title;
            _context.Update<Post>(_temp);
            _context.SaveChanges();
            model.IsSuccess = true;
            return model;

        }


        public ResponseModel DeletePost(int Id)
        {
            ResponseModel Model = new ResponseModel();
            Post post = GetPostById(Id);
            if (post != null)
            {
                _context.Remove<Post>(post);
                _context.SaveChanges();
                Model.IsSuccess = true;
                Model.Messsage = "PostDeletedSuccessfully";
            }
            else
            {
                Model.IsSuccess = false;
                Model.Messsage = "UserNotFound";
            }
            return Model;
        }


    }
}
