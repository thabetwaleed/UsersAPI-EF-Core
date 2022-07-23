using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;
using UsersAPI.ViewModels;

namespace UsersAPI.Repos
{
    public class UserRepos:IUserService
    {

        private UserContext _context;

        public UserRepos(UserContext context)
        {
            _context = context;
        }
         
        public  List<User> GetUsersList()
        {
            List<User> UsersList;
            try
            {
                UsersList = _context.Set<User>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return UsersList;
        }


        public User GetUserById(int Id)
        {
            User user;
            try
            {
                user = _context.Find<User>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public ResponseModel SaveUser(User user)
        {
            

            ResponseModel model=new ResponseModel();
            User TempUser=GetUserById(user.Id);
            if (TempUser != null)
            {
                TempUser.FName = user.FName;
                TempUser.LName=user.LName;
                TempUser.BOD = user.BOD;
                _context.Update<User>(TempUser);
                model.Messsage = "Updated Successfully";
            }   
            else
            {   
                _context.Add<User>(user);
                model.Messsage = "Added Successfully";
            }
               _context.SaveChanges();
                model.IsSuccess = true;
                return model;
        }



        public ResponseModel DeleteUser(int Id)
        {
            ResponseModel Model=new ResponseModel();
            User user=GetUserById(Id);
            if (user != null)
            {
                _context.Remove<User>(user);
                _context.SaveChanges();
                Model.IsSuccess = true;
                Model.Messsage = "UserAddedSuccessfully";
            }
            else
            {
                Model.IsSuccess= false;
                Model.Messsage = "UserNotFound";
            }
            return Model;
        }
        
    }
}
