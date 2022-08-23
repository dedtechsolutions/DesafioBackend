using Microsoft.AspNetCore.Mvc;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
   

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "")]
        public IEnumerable<Object> Get()
        {
            throw new NotImplementedException();    
        }
        [HttpGet(Name = "{id}")]
        public IEnumerable<Object> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPost(Name = "")]
        public IEnumerable<Object> Post(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPut(Name = "{id}")]
        public IEnumerable<Object> Put(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}