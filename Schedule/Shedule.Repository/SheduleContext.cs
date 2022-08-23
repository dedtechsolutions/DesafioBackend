using Microsoft.EntityFrameworkCore;
using Shedule.Domain;

namespace Shedule.Repository
{
    public class SheduleContext : DbContext
    {
        public SheduleContext(DbContextOptions<SheduleContext> options)
             : base(options) { }

        public DbSet<Assignment> Assignments => Set<Assignment>();
    }
}
