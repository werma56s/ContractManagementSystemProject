using AutoMapper;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Contract;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Contract, ContractDto>();
    }
}
