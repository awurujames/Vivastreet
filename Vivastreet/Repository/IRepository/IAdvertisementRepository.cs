using Vivastreet.Models;
using Vivastreet_Models;

namespace Vivastreet.Repository.IRepository
{
    public interface IAdvertisementRepository : IRepository<Advertisement>
    {
        void Update(Advertisement obj);
    }
}
