using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        
        public User? user { get; set; }
    }
}
