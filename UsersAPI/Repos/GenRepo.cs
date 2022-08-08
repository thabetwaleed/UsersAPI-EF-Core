using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using UsersAPI.Model;


namespace UsersAPI.Repos
{

    
    public interface IGenRepo<T> where T : class
    {
        public Task<List<TVM>?> Get<TVM>() where TVM:class,IBaseModel;
        public ValueTask<TVM?> GetId<TVM>(int id) where TVM:class,IBaseModel;
        public Task<T> Add(T model,int userid);
        public T Update(T model,int userid);
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

        public async Task<T>  Add(T model,int userid)
        {

            var type = model.GetType();
            var CreateDate = type.GetProperties().FirstOrDefault(c=>c.Name== "CreateDate");
            var CreateBy = type.GetProperties().FirstOrDefault(c => c.Name == "CreateBy");
            if (CreateDate!= null)
            {
                var CreateDatenow = DateTime.Now;
                CreateDate.SetValue(model, CreateDatenow);
                CreateBy.SetValue(model, userid);

            }
              await _context.Set<T>().AddAsync(model);
              await  _context.SaveChangesAsync();
             return model;

        }
        
        public async Task<TVM>  Delete<TVM>(int id) where TVM:class,IBaseModel
        {
             var _temp = await GetId<TVM>(id);
             _context.Set<T>().Remove(_mapper.Map<T>(_temp));
              await _context.SaveChangesAsync();
              return _mapper.Map<TVM>(_temp);

        }

        public async Task<List<TVM>> Get<TVM>() where TVM:class,IBaseModel
        {
            
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async ValueTask<TVM?> GetId<TVM>(int id) where TVM : class, IBaseModel
        {
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);

        }

        public T Update(T model,int userid)
        {
            var type = model.GetType();
            var UpdateDate = type.GetProperties().FirstOrDefault(c => c.Name == "UpdateDate");
            var UpdateBy = type.GetProperties().FirstOrDefault(c => c.Name == "UpdateBy");
            
            if (UpdateDate != null)
            {
                
                UpdateDate.SetValue(model, DateTime.Now);
                UpdateBy.SetValue(model, userid);
                
                var CreatedDate=type.GetProperties().FirstOrDefault(c=>c.Name=="CreateDate");
                var CreatedBy = type.GetProperties().FirstOrDefault(c => c.Name == "CreateBy");

                var record = _context.Post.AsNoTracking().FirstOrDefault(c => c.Id == model.Id);
                 
                

                CreatedDate.SetValue(model,record.CreateDate);
                CreatedBy.SetValue(model,record.CreateBy);
                
            }

            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }

         
    }
}
