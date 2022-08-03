using AutoMapper;
using UsersAPI.Model;

namespace UsersAPI.Repos
{

    public interface INewPostRepo : IGenRepo<Post>
    {

    }

    public class NewPostRepo : GenRepo<Post>, INewPostRepo
    {

        public NewPostRepo(UserContext context,IMapper mapper) : base(context,mapper)
        {
        }
    }
}
