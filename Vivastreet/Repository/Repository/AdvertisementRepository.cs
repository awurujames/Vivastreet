using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Repository.Repository
{
    public class AdvertisementRepository : Repository<Advertisement>, IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;
        public AdvertisementRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }
    }
}
