using Vivastreet.Repository.IRepository;
using Vivastreet_DataAccess;
using Vivastreet_Models;

namespace Vivastreet.Repository.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(City obj)
        {
            var objFromRepo = _context.Citys.FirstOrDefault(x => x.Id == obj.Id);
            {
                if(objFromRepo == null)
                {
                    objFromRepo.CityName = obj.CityName;
                    
                }
            }
        }

        //public void Update(City obj)
        //{
        //    var objFromDb = _context.Rates.FirstOrDefault(u => u.Id == obj.Id);
        //    {
        //        if (objFromDb != null)
        //        {
        //            objFromDb.LocalPickUp = obj.LocalPickUp;
        //            objFromDb.Name = obj.Name;
        //            objFromDb.Delivery = obj.Delivery;
        //            objFromDb.Advertisement = obj.Advertisement;
        //        }
        //    };
        //}
    }
}
