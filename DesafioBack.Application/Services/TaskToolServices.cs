using AutoMapper;
using DesafioBack.Application.DTOs;
using DesafioBack.Application.Interfaces;
using DesafioBack.Domain.Entity;
using DesafioBack.Domain.Interfaces;
using DesafioBack.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioBack.Application.Services
{
    public class TaskToolServices : ITaskToolServices
    {
        private ITaskToolRepository _tasksRepository;
        private readonly IMapper _mapper;

        public TaskToolServices(ITaskToolRepository tasksRepository, IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskToolDTOOutput>> FindByAll()
        {
            var tasksEntity = await _tasksRepository.FindByAll();
            return _mapper.Map<IEnumerable<TaskToolDTOOutput>>(tasksEntity);
        }

        public async Task<TaskToolDTOOutput> FindById(int id)
        {
            var tasksEntity = await _tasksRepository.FindById(id);
            ValidIdEntity(tasksEntity, id);
            return _mapper.Map<TaskToolDTOOutput>(tasksEntity);
        }

        public async Task Create(TaskToolDTOInput tasks)
        {
            var tasksConvert = ConvertInputToDTOCreate(tasks);
            var TasksEntity = _mapper.Map<TaskTool>(tasksConvert);
            await _tasksRepository.Create(TasksEntity);
        }

        public async Task Update(TaskToolDTOInput tasks)
        {
            var getDateCreate = await _tasksRepository.FindById(tasks.Id);
            var tasksConvert = ConvertInputToDTOUpdate(tasks, getDateCreate.DataCriacao);
            var TasksEntity = _mapper.Map<TaskTool>(tasksConvert);
            await _tasksRepository.Update(TasksEntity);
        }

        public async Task Remove(int id)
        {
            var tasksEntity = _tasksRepository.FindById(id).Result;
            ValidIdEntity(tasksEntity, id);
            await _tasksRepository.Remove(tasksEntity);
        }

        private static void ValidIdEntity(TaskTool tasksEntity, int id)
        {
            if (tasksEntity is null)
                DomainExceptionValidation.ErrorId("Id " + id + " Not have data");
        }

        private static TaskToolDTOOutput ConvertInputToDTOCreate(TaskToolDTOInput tasks)
        {
            return new TaskToolDTOOutput
            {
                Titulo = tasks.Titulo,
                Descricao = tasks.Descricao,
                DataCriacao = DateTime.Now,
                DataAtualizacao = null
            };
        }

        private static TaskToolDTOOutput ConvertInputToDTOUpdate(TaskToolDTOInput tasks, DateTime dataCriacao)
        {
            return new TaskToolDTOOutput
            {
                Id = tasks.Id,
                Titulo = tasks.Titulo,
                Descricao = tasks.Descricao,
                DataCriacao = dataCriacao,
                DataAtualizacao = DateTime.Now
            };
        }
    }
}
