using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositorio.DAL;
using Domain.Entidades;
using System;
using System.Globalization;
using Repositorio.Interfaces;
using Application.Services.Interfaces;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected readonly IVendaProdutoRepository _vendaProdutoRepository;
        protected IGraficoService _graficoService;
        protected readonly IMapper _mapper;

        public RelatorioController(IVendaProdutoRepository vendaProdutoRepository, IMapper mapper, IGraficoService graficoService)
        {
            _vendaProdutoRepository = vendaProdutoRepository;
            _mapper = mapper;
            _graficoService = graficoService;
        }

        public IActionResult Grafico()
        {

            var consulta = _vendaProdutoRepository.Grafico();

            var modelo = _graficoService.Grafico(consulta);

            ViewBag.Valores = modelo.Valores;
            ViewBag.Labels = modelo.Labels;
            ViewBag.Cores = modelo.Cores;

            return View();
        }


    }
}
