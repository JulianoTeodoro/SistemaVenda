using Application.Services.Interfaces;
using AutoMapper;
using Domain.Servicos;
using SistemaVenda.Models;

namespace Application.Services
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        protected ICategoriaService _categoriaService;
        protected IMapper _mapper;
        public ServicoAplicacaoCategoria(ICategoriaService categoriaService, IMapper mapper )
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = _categoriaService.Listagem();

            var viewModel = _mapper.Map<List<CategoriaViewModel>>(lista);

            return viewModel;
        }
    }
}
