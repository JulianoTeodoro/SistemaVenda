using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Models;
using System.Diagnostics;
using SistemaVenda.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        protected readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           /* var categoria = new Categoria
            {
                Nome = "Eletrodomesticos"
            };
            _context.Categorias.Add(categoria);

            _context.SaveChanges();*/
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}