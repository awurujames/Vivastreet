using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Repository.Repository
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly ApplicationDbContext _context;
        public MaterialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
