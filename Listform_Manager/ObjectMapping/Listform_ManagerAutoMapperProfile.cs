using AutoMapper;
using Listform_Manager.Entities;
using Listform_Manager.Services.Dtos;

namespace Listform_Manager.ObjectMapping;

public class Listform_ManagerAutoMapperProfile : Profile
{
    public Listform_ManagerAutoMapperProfile()
    {
        CreateMap<Listform, ListformDto>().ReverseMap();
        CreateMap<ListformField, ListformFieldDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
