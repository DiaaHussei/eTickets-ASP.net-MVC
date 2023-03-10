using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;


namespace eTickets.Data.Services
{
    public class CinemasServicec: EntityBaseRepository<Cinema> ,ICinemasService
    {

        public CinemasServicec(AppDbContext appDb) : base(appDb) { }
    }
}
