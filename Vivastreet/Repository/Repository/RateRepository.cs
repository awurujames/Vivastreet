using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Repository.Repository
{
    public class RateRepository : Repository<Rate>, IRateRepository
    {
        private readonly ApplicationDbContext _context;
        public RateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
