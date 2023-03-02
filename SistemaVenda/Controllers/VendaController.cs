using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;
using Repositorio.Interfaces;
using Application.Services.Interfaces;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {

        protected IVendaRepository _vendaRepository;
        protected readonly IMapper _mapper;
        protected readonly IVendaService _vendaService;

        public VendaController(IVendaRepository vendaRepository, IMapper mapper, IVendaService vendaService)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
            _vendaService = vendaService;
        }

        public IActionResult Index()
        {
            var vendas = _vendaRepository.Get();

            return View(vendas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var venda = _vendaService.Form();

            return View(venda);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendaFormViewModel vendaFormView)
        {
            if (!ModelState.IsValid)
            {
                var vendaForm = _vendaService.Form();

                return View(vendaForm);
            }


            var vendaView = _vendaService.Criacao(vendaFormView);

            var venda = _mapper.Map<Venda>(vendaView);

            _vendaRepository.Create(venda);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("LerValorProduto/{id}")]
        public double LerValorProduto(int id)
        {
            return _vendaService.LerValorProduto(id);
        }

    }
}
