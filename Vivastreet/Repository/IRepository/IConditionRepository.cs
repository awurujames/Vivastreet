using Vivastreet.Models;
using Vivastreet_Models;

namespace Vivastreet.Repository.IRepository
{
    public interface IConditionRepository : IRepository<Condition>
    {
        void Update(Condition obj);
    }
}
