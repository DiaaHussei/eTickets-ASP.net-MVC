using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor> , IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext appDb):base(appDb){}
        //public void Add(Actor actor)
        //{
        //    _context.Add(actor);
        //    _context.SaveChanges();
        //}

        //public async Task Delete(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id );
        //      _context.Actors.Remove(result);
        //     await _context.SaveChangesAsync();
            
        //}

        //public IEnumerable<Actor> GetAll()
        //{
        //    var result = _context.Actors.ToList();
        //    return result;
        //}

        //public async Task<Actor> GetById(int id)
        //{
        //  var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;

        //}

        //public async Task<Actor> Update(int id, Actor actor)
        //{
        //    _context.Update(actor);
        //    await _context.SaveChangesAsync();
        //    return actor;
        //}
    }
}
