using Vivastreet.Models;
using Vivastreet_Models;

namespace Vivastreet.Repository.IRepository
{
    public interface IMaterialRepository : IRepository<Material>
    {
        void Update(Material obj);
    }
}
