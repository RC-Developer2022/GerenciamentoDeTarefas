using AutoMapper;
using Tarefas.Application.DTO;
using Tarefas.Domain.Entitys;

namespace Tarefas.Application.AutoMapper;

public class AutoMapperProfilecs : Profile
{
    public AutoMapperProfilecs()
    {
        CreateMap<Person, PersonDTO>()
            .ReverseMap();
    }
}
