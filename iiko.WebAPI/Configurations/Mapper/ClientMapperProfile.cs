using AutoMapper;
using WebAPI.Dto;
using WebAPI.Entities;

namespace WebAPI.Configurations;

public class ClientMapperProfile : Profile
{
    public ClientMapperProfile()
    {
        CreateMap<CreateClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
    }   
}