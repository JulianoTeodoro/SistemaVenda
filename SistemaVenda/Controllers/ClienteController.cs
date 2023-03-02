using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositories;
using Repositorio.Interfaces;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {

        protected IClienteRepository _clienteRepository;
        protected IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var clientes = _clienteRepository.Get();
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
            _clienteRepository.Create(client);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var cliente = _clienteRepository.GetById(p => p.Id == id);

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
            _clienteRepository.Update(client);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao remover");
            }

            var cliente = _clienteRepository.GetById(p => p.Id == id);

            var clienteView = _mapper.Map<ClienteViewModel>(cliente);
            return View(clienteView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(ClienteViewModel cliente)
        {

            var client = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Delete(client);

            return RedirectToAction("Index");

        }



    }
}
