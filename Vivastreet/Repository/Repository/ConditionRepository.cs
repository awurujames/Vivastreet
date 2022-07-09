using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Repository.Repository
{
    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        private readonly ApplicationDbContext _context;
        public ConditionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
