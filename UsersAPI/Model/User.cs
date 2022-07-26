
namespace UsersAPI.Model
{
    public class User:BaseModel
    {
        
         public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BOD { get; set; }

        public ICollection<Post>? posts { get; set; }
        

    }
}
