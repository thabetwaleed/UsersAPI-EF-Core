
using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Model
{
    public class User:IdentityUser<int>,IBaseModel //<int> because the id in IBasemodel is int  
    {
        
         public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BOD { get; set; }

        public ICollection<Post>? posts { get; set; }
        

    }
}
