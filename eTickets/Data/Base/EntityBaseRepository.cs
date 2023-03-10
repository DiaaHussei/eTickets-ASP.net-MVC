using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBaseRepostory, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext appDb)
        {

            _context = appDb;

        }
        public void Add(T en)
        {
            _context.Set<T>().Add(en); 
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry(result);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }


        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id ==id);
            return result;
        }

        public async Task Update(int id, T en)
        {
            EntityEntry entityEntry = _context.Entry<T>(en);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
             
        }
    }
}
