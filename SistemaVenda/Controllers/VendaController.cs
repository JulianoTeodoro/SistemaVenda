using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {

        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public VendaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var vendas = _context.Vendas.ToList();

            return View(vendas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var clientes = _context.Clientes.ToList();
            var clienteView = _mapper.Map<List<ClienteViewModel>>(clientes);

            var produtos = _context.Produtos.ToList();
            var produtoView = _mapper.Map<List<ProdutoViewModel>>(produtos);

            var vendaForm = new VendaFormViewModel
            {
                ListaProdutos = produtoView,
                ListaClientes = clienteView
            };

            return View(vendaForm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendaFormViewModel vendaFormView)
        {
            if (!ModelState.IsValid)
            {
                var clientes = _context.Clientes.ToList();
                var clienteView = _mapper.Map<List<ClienteViewModel>>(clientes);

                var produtos = _context.Produtos.ToList();
                var produtoView = _mapper.Map<List<ProdutoViewModel>>(produtos);

                var vendaForm = new VendaFormViewModel
                {
                    ListaProdutos = produtoView,
                    ListaClientes = clienteView
                };

                return View(vendaForm);
            }

            var VendaProdutos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(vendaFormView.Venda.JsonProdutos);

            double valorTotal = 0;

            foreach(var produto in VendaProdutos)
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

            var venda = _mapper.Map<Venda>(vendaView); 
            
            _context.Vendas.Add(venda);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
        }

        [HttpGet("LerValorProduto/{id}")]
        public double LerValorProduto(int id)
        {
            return _context.Produtos.Where(p => p.Id == id).Select(p => p.Valor).FirstOrDefault();
        }

    }
}
