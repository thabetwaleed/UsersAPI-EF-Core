using UsersAPI.Model;

namespace UsersAPI.ViewModel
{
    public class PostViewModel:BaseModel
    {
        public string Title { get; set; }
        public int UserId { get; set; }
     }
}
