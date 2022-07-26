using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Model
{
    public interface IBaseModel
    {
        public int Id { get; set; }

    }
    public class BaseModel:IBaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
