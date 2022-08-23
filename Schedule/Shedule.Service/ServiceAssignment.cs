using Microsoft.Extensions.Logging;
using Shedule.Domain;
using Shedule.Repository;

namespace Shedule.Service
{
    public class ServiceAssignment : IServiceAssignment
    {
        private readonly ILogger<ServiceAssignment> _logger;
        private readonly IRepositoryAssignment _repository;
        public ServiceAssignment(ILogger<ServiceAssignment> logger, IRepositoryAssignment repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<Assignment?> Create(Assignment? assignment)
        {
            if (assignment == null)
                return null;
            return await _repository.Create(assignment);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Assignment>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Assignment?> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<Assignment> Update(Guid id, Assignment assignment)
        {
            return await _repository.Update(id, assignment);
        }
    }
}
