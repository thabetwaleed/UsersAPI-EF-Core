using UsersAPI.Model;

namespace UsersAPI.ViewModel
{
    public class UserViewModel:BaseModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BOD { get; set; }
    }
}
