using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Model
{
    public class Post:BaseModel
    {

         public string Title { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        
        public virtual User? user { get; set; }
    }
}
