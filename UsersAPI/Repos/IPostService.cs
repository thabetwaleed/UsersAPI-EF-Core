using UsersAPI.Model;
using UsersAPI.ViewModels;

namespace UsersAPI.Repos
{
    public interface IPostService
    {
        List<Post> GetPostsList();
        Post GetPostById(int Id);
        ResponseModel Add(Post post);
        ResponseModel Update(Post post);
        ResponseModel DeletePost(int Id);
    }
}
