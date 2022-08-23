using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shedule.Domain;

namespace Shedule.Repository
{
    public class RepositoryAssignment : IRepositoryAssignment

    {
        private readonly ILogger<RepositoryAssignment> _logger;
        private readonly SheduleContext _db;
        public RepositoryAssignment(ILogger<RepositoryAssignment> logger, SheduleContext db)
        {
            _logger = logger;
            _db = db;
        }
        public async Task<Assignment> Create(Assignment assignment)
        {
            assignment.Id = Guid.NewGuid();
            assignment.CreateOn = DateTime.Now;
            assignment.UpdateOn = DateTime.Now;
            _db.Assignments.Add(assignment);
            await _db.SaveChangesAsync();
            return assignment;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (await _db.Assignments.FindAsync(id) is Assignment find)
            {
                _db.Assignments.Remove(find);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Assignment>> Get()
        {
            return await _db.Assignments.ToListAsync();
        }

        public async Task<Assignment?> Get(Guid id)
        {
           return  await _db.Assignments.FindAsync(id);
        }

        public async Task<Assignment?> Update(Guid id, Assignment assignment)
        {
            var find = await _db.Assignments.FindAsync(id);
            if (find is null) return null;
            find.Title = assignment.Title;
            find.Description = assignment.Description;
            find.UpdateOn = DateTime.Now;
            await _db.SaveChangesAsync();
            return find;

        }
    }
}
