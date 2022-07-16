using Vivastreet.Repository.IRepository;
using Vivastreet_DataAccess;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class RateRepository : Repository<Rate>, IRateRepository
    {
        private readonly ApplicationDbContext _context;
        public RateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Rate obj)
        {
            var objFromDb = _context.Rates.FirstOrDefault(u => u.Id == obj.Id);
            {
                if (objFromDb != null)
                {
                    objFromDb.LocalPickUp = obj.LocalPickUp;
                    objFromDb.Name = obj.Name;
                    objFromDb.Delivery = obj.Delivery;
                    objFromDb.Advertisement = obj.Advertisement;
                }
            };
        }
    }
}
