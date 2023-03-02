using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Newtonsoft.Json;
using Repositorio.Interfaces;
using SistemaVenda.Models;

namespace Application.Services.Venda
{
    public class VendaService : IVendaService
    {
        protected IVendaRepository _vendaRepository;
        protected IClienteRepository _clienteRepository;
        protected IProdutoRepository _produtoRepository;
        protected readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public VendaViewModel Criacao(VendaFormViewModel vendaFormView)
        {

            var VendaProdutos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(vendaFormView.Venda.JsonProdutos);

            double valorTotal = 0;

            foreach (var produto in VendaProdutos)
            {
                valorTotal += produto.ValorTotal;
            }

            var vendaView = new VendaViewModel
            {
                ClienteId = vendaFormView.Venda.ClienteId,
                DataVenda = (DateTime)vendaFormView.Venda.DataVenda,
                Produtos = VendaProdutos,
                ValorTotal = valorTotal,
            };

            return vendaView;
        }

        public VendaFormViewModel Form()
        {
            var clientes = _clienteRepository.Get();
            var clienteView = _mapper.Map<List<ClienteViewModel>>(clientes);

            var produtos = _produtoRepository.Get();
            var produtoView = _mapper.Map<List<ProdutoViewModel>>(produtos);

            var vendaForm = new VendaFormViewModel
            {
                ListaProdutos = produtoView,
                ListaClientes = clienteView
            };

            return vendaForm;
        }

        public double LerValorProduto(int id)
        {
            return _produtoRepository.LerValorProduto(id);
        }
    }
}
