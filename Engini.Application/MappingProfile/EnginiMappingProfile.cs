using AutoMapper;
using Engini.Application.Features.Employee;
using Engini.Domain.Entities;

namespace Engini.Application.MappingProfile;

public sealed class EnginiMappingProfile : Profile
{
    public EnginiMappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}
