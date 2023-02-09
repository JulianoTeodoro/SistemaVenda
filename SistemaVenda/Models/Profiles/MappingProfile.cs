using AutoMapper;
using SistemaVenda.Entidades;

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
