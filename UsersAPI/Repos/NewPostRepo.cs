using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using UsersAPI.Model;

namespace UsersAPI.Repos
{

    public interface INewPostRepo : IGenRepo<Post>
    {
        public  Task<List<Post>> GetAllPosts(int page,int size,string s);
 
    }

    public class NewPostRepo : GenRepo<Post>, INewPostRepo
    {
        private readonly UserContext _context;
        public NewPostRepo(UserContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
        
               
       
        public async Task<List<Post>> GetAllPosts(int page,int size,string s)
        {

            return await _context.Post.Where(x=>x.Title.Contains(s)).Skip<Post>(page*size).Take<Post>(size).ToListAsync();
        }


    }
}
