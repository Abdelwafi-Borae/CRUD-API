using CRUD_Operation_Repository.Data;
using CRUD_Operation_Repository.DTOS;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD_Operation_Repository.Services.Common_service
{
    public class Common_Service<T> : ICommon_Service<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Common_Service(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddItem(T Item)
        {
            await _context.Set<T>().AddAsync(Item);
            return Item;

        }
        public void RemoveItem(T Item)
        {
            _context.Set<T>().Remove(Item);
        }

        public T UpdateItem(T Item)
        {
            _context.Set<T>().Update(Item);
            return Item;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> GetByCrateria(Expression<Func<T, bool>> match, string[] include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
                foreach (var item in include)
                    query = query.Include(item);
            return await query.Where(match).ToListAsync();
        }

        public async Task<T> GetByID(int Id)
        {

            var item = await _context.Set<T>().FindAsync(Id);
             
            
            return item;
        }
    }
}
