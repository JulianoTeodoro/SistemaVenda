using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using System;
using System.Globalization;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public RelatorioController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Grafico()
        {

            var consulta = _context.VendaProdutos.GroupBy(p => p.ProdutoId)
                                                 .Select(y => new Grafico
                                                 {
                                                     CodigoProduto = y.First().ProdutoId,
                                                     Descricao = y.First().Produto.Nome,
                                                     TotalVendido = y.Sum(z => z.Quantidade)
                                                 }).ToList();

            string valores = string.Empty; 
            string labels = string.Empty;
            string cores = string.Empty;

            var random = new Random();

            for(int i = 0; i < consulta.Count; i++)
            {
                valores += consulta[i].TotalVendido.ToString() + ",";
                labels += "'" + consulta[i].Descricao.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x100000) + "',");
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }


    }
}
