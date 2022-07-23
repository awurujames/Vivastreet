using Vivastreet.Models;
using Vivastreet_Models;

namespace Vivastreet.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City obj);

    }
}
