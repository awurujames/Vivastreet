using Vivastreet.Models;
using Vivastreet_Models;

namespace Vivastreet.Repository.IRepository
{
    public interface IRateRepository : IRepository<Rate>
    {
        void Update(Rate obj);

    }
}
