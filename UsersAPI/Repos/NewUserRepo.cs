using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;

namespace UsersAPI.Repos
{

    public interface INewUserRepo : IGenRepo<User>
    {
        public Task<bool> DeletePosts(int UserId);

    }

    public class NewUserRepo : GenRepo<User>, INewUserRepo
    {
        UserContext _context;
        public NewUserRepo(UserContext context,IMapper mapper) : base(context,mapper)
        {
            _context = context;
        }


        public async Task<bool> DeletePosts(int UserId)
        {
            var PostsReferenceUser =await _context.Post.Where(c => c.UserId == UserId).ToListAsync();
            foreach (var post in PostsReferenceUser)
            {
                _context.Post.Remove(post);
            }

            return true;
        }
    }
}
