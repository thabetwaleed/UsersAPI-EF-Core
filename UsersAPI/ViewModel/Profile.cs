using AutoMapper;
using UsersAPI.Model;

namespace UsersAPI.ViewModel
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {       //source to destination
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
    }
}
