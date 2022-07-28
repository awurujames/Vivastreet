using Vivastreet_DataAccess;
using Vivastreet.Models;
using Vivastreet.Repository.IRepository;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly ApplicationDbContext _context;
        public MaterialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Material obj)
        {
            var objFromDb = _context.Materials.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Durability = obj.Durability;
                objFromDb.Type = obj.Type;  
            }
        }
    }
}
