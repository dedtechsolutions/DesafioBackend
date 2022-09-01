using DesafioBack.Domain.Entity;
using DesafioBack.Domain.Interfaces;
using DesafioBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBack.Infra.Data.Repository
{
    public class TaskToolRepository : ITaskToolRepository
    {
        ApplicationDbContext _categoryContext;

        public TaskToolRepository(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<TaskTool> Create(TaskTool tasksTool)
        {
            _categoryContext.Add(tasksTool);
            await _categoryContext.SaveChangesAsync();
            return tasksTool;
        }

        public async Task<IEnumerable<TaskTool>> FindByAll()
        {
            return await _categoryContext.TaskTool.ToListAsync();
        }

        public async Task<TaskTool> FindById(int id)
        {
            return await _categoryContext.TaskTool.FindAsync(id);
        }

        public async Task<TaskTool> Update(TaskTool tasksTool)
        {
            _categoryContext.Update(tasksTool);
            await _categoryContext.SaveChangesAsync();
            return tasksTool;
        }

        public async Task<TaskTool> Remove(TaskTool tasksTool)
        {
            _categoryContext.Remove(tasksTool);
            await _categoryContext.SaveChangesAsync();
            return tasksTool;
        }
    }
}
