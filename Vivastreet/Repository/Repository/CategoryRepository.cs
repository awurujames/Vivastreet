using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            var objFromDb = _db.Categories.FirstOrDefault(c => c.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.DisplayOder = obj.DisplayOder;    
            }

        }
    }
}
