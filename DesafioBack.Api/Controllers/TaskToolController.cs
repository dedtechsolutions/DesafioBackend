using DesafioBack.Application.DTOs;
using DesafioBack.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToolController : ControllerBase
    {
        private ITaskToolServices _taskToolServices;

        public TaskToolController(ITaskToolServices taskToolServices)
        {
            _taskToolServices = taskToolServices;
        }

        [HttpGet("{id}")]
        public async Task<TaskToolDTOOutput> GetById(int id)
        {
            return await _taskToolServices.FindById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<TaskToolDTOOutput>> GetCategories()
        {
            return await _taskToolServices.FindByAll();
        }

        [HttpPost]
        public async Task Add(TaskToolDTOInput taskToolDTO)
        {
            
            await _taskToolServices.Create(taskToolDTO);
        }

        [HttpPut]
        public async Task Update(TaskToolDTOInput taskToolDTO)
        {
            await _taskToolServices.Update(taskToolDTO);
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await _taskToolServices.Remove(id);
        }
    }
}
