using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Model
{
    public class Post:BaseModel
    {

         public string? Title { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
                
       public virtual User? user { get; set; } //not necessary 

        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
