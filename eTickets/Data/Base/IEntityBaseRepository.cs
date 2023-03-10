using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository <T> where T: class,IEntityBaseRepostory, new()
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id);
        void Add(T en);
        Task Update(int id, T en );
        Task Delete(int id);
    }
}
