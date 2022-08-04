using System.ComponentModel.DataAnnotations;
using UsersAPI.Model;

namespace UsersAPI.ViewModel
{
    public class UserViewModel:BaseModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BOD { get; set; }

        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
