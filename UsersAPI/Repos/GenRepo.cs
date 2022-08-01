using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;


namespace UsersAPI.Repos
{

    
    public interface IGenRepo<T> where T : class
    {
        public Task<List<T>> Get();
        public ValueTask<T?> GetId(int id);
        public Task<T> Add(T model);
        public T Update(T model);
        public Task<T> Delete(int id);
               

    }


    public class GenRepo<T>:IGenRepo<T> where T : class, IBaseModel
    {
        private readonly UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public async Task<T>  Add(T model)
        {
              await _context.Set<T>().AddAsync(model);
              await  _context.SaveChangesAsync();
             return model;

        }

        public  async Task<T>  Delete(int id)
        {
             var _temp = await GetId(id);
             _context.Set<T>().Remove(_temp);
             await _context.SaveChangesAsync();
            return _temp;
            
        }

        public async Task<List<T>> Get()
        {
            var G = await _context.Set<T>().ToListAsync();
            int c = 0;
            return G;
        }

        public ValueTask<T?> GetId(int id)
        {
            ValueTask<T?> x =  _context.Set<T>().FindAsync(id);
            return x;
        }

        public T Update(T model)
        {

            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
