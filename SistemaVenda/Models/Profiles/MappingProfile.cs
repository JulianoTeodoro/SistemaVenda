using AutoMapper;
using Domain.Entidades;

namespace SistemaVenda.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
        }
    }
}
