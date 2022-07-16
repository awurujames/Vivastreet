using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class AdvertisementRepository : Repository<Advertisement>, IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;
        public AdvertisementRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Update(Advertisement obj)
        {
            _context.Advertisements.Update(obj);
        }
    }
}
