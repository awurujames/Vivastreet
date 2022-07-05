using Vivastreet.Data;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;

namespace Vivastreet.Repository.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
