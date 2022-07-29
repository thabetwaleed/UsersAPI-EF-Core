using UsersAPI.Model;

namespace UsersAPI.Repos
{

    
    public interface IGenRepo<T> where T : class
    {
        public List<T> Get();
        public T GetId(int id);
        public T Add(T model);
        public T Update(T model);
        public void Delete(int id);
               

    }


    public class GenRepo<T>:IGenRepo<T> where T : class, IBaseModel
    {
        private readonly UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public T Add(T model)
        {
             _context.Set<T>().Add(model);
             _context.SaveChanges();
            return model;

        }

        public void Delete(int id)
        {
            var _temp = GetId(id);
            _context.Set<T>().Remove(_temp);
            _context.SaveChanges();

        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T model)
        {

            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
