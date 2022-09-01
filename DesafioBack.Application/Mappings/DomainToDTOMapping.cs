using AutoMapper;
using DesafioBack.Application.DTOs;
using DesafioBack.Domain.Entity;

namespace DesafioBack.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<TaskTool, TaskToolDTOOutput>().ReverseMap();
        }
    }
}
