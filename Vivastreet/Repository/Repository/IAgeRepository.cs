using System.Linq.Expressions;
using Vivastreet.Repository.IRepository;
using Vivastreet_DataAccess;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class AgeRepository : Repository<SelectAge>, IAgeRepository
    {
        private readonly ApplicationDbContext _context;
        public AgeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

       

        public void Update(SelectAge obj)
        {
            var objFromDb = _context.selectAges.FirstOrDefault(u => u.Id == obj.Id);
            {
                if (objFromDb != null)
                {
                    objFromDb.Age = obj.Age;
                }
            };
        }

       
    }
}
