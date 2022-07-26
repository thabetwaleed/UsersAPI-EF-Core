using UsersAPI.Model;

namespace UsersAPI.Repos
{

    public interface INewUserRepo : IGenRepo<User>
    {

    }

    public class NewUserRepo : GenRepo<User>, INewUserRepo
    {

        public NewUserRepo(UserContext context) : base(context)
        {
        }
    }
}
