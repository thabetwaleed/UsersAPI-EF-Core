using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Model;


namespace UsersAPI.Repos
{

    
    public interface IGenRepo<T> where T : class
    {
        public Task<List<TVM>?> Get<TVM>() where TVM:class,IBaseModel;
        public ValueTask<TVM?> GetId<TVM>(int id) where TVM:class,IBaseModel;
        public Task<T> Add(T model);
        public T Update(T model);
        public Task<TVM> Delete<TVM>(int id) where TVM:class,IBaseModel;
               

    }


    public class GenRepo<T>:IGenRepo<T> where T : class, IBaseModel
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;
        public GenRepo(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<T>  Add(T model)
        {
              await _context.Set<T>().AddAsync(model);
              await  _context.SaveChangesAsync();
             return model;

        }

        public async Task<T>  Delete<TVM>(int id) where TVM:class,IBaseModel
        {
             var _temp = await GetId<TVM>(id);
             _context.Set<T>().Remove(_mapper.Map<T>(_temp));
              await _context.SaveChangesAsync();
              return _mapper.Map<T>(_temp);

        }

        public async Task<List<TVM>> Get<TVM>() where TVM:class,IBaseModel
        {
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async ValueTask<TVM?> GetId<TVM>(int id) where TVM : class, IBaseModel
        {
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);

        }

        public T Update(T model)
        {

            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }

        Task<TVM> IGenRepo<T>.Delete<TVM>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
