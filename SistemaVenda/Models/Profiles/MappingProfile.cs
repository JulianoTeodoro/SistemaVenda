using AutoMapper;
using SistemaVenda.Entidades;

namespace SistemaVenda.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
