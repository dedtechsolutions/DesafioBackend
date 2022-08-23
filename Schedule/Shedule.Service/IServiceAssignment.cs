using Shedule.Domain;

namespace Shedule.Service
{
    public interface IServiceAssignment
    {
        Task<IEnumerable<Assignment>> Get();
        Task<Assignment?> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<Assignment> Update(Guid id, Assignment assignment);
        Task<Assignment?> Create(Assignment? assignment);
    }
}
