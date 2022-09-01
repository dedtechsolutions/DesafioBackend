using DesafioBack.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBack.Application.Interfaces
{
    public interface ITaskToolServices
    {
        Task<IEnumerable<TaskToolDTOOutput>> FindByAll();
        Task<TaskToolDTOOutput> FindById(int id);
        Task Create(TaskToolDTOInput tasks);
        Task Update(TaskToolDTOInput tasks);
        Task Remove(int id);
    }
}
