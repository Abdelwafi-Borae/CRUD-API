using CRUD_Operation_Repository.DTOS;
using System.Linq.Expressions;

namespace CRUD_Operation_Repository.Services.Common_service
{
    public interface ICommon_Service<T> where T : class

    {
        public Task< T> AddItem(T Item);
        public T UpdateItem(T Item);
        public   void RemoveItem(T Item);
        public Task<T> GetByID(int Id);
        public  Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> GetByCrateria(Expression< Func<T,bool>> match,string[]? include=null );
        
    }
}
