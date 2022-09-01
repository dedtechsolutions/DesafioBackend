using DesafioBack.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBack.Domain.Interfaces
{
    public interface ITaskToolRepository
    {
        Task<IEnumerable<TaskTool>> FindByAll();
        Task<TaskTool> FindById(int id);
        Task<TaskTool> Create(TaskTool tasksTool);
        Task<TaskTool> Update(TaskTool tasksTool);
        Task<TaskTool> Remove(TaskTool tasksTool);
    }
}
