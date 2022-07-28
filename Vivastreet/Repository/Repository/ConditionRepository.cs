using Vivastreet_Models;
using Vivastreet.Repository.IRepository;
using Vivastreet_DataAccess;

namespace Vivastreet.Repository.Repository
{
    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        private readonly ApplicationDbContext _context;
        public ConditionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Condition obj)
        {
            var objFromDb = _context.Conditions.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
            }
        }
    }
}
