using UsersAPI.Model;
using UsersAPI.ViewModels;
using System.Collections.Generic;


namespace UsersAPI.Repos
{
    public interface IUserService
    { 
        List<User> GetUsersList();   
        User GetUserById(int Id);        
        ResponseModel Add(User UserModel);         
        ResponseModel Update(User UserModel);         
        ResponseModel DeleteUser(int Id);
    }
}

 