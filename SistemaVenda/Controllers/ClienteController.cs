using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {

        protected readonly ApplicationDbContext _context;
        protected IMapper _mapper;

        public ClienteController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var clientes = _context.Clientes.ToList();
            var clienteView = _mapper.Map<List<ClienteViewModel>>(clientes);

            return View(clienteView);
        }

        
        public IActionResult Create()
        {
            var cliente = new ClienteViewModel();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(cliente);
            }

            var client = _mapper.Map<Cliente>(cliente);
            _context.Clientes.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.Id == id);

            var clienteView = _mapper.Map<ClienteViewModel>(cliente);
            return View(clienteView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(cliente);
            }

            var client = _mapper.Map<Cliente>(cliente);
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao remover");
            }

            var cliente = _context.Clientes.FirstOrDefault(p => p.Id == id);

            var clienteView = _mapper.Map<ClienteViewModel>(cliente);
            return View(clienteView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(ClienteViewModel cliente)
        {

            var client = _mapper.Map<Cliente>(cliente);
            _context.Clientes.Remove(client);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }



    }
}
