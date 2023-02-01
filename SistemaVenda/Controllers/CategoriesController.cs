using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriesController : Controller
    {

        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();

            return View(categorias);
        }

        public IActionResult Create()
        {
            var categoria = new CategoriaViewModel();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            var category = _mapper.Map<Categoria>(categoria);

            _context.Categorias.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao editar");
            }

            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id);
            var category = _mapper.Map<CategoriaViewModel>(categoria);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaViewModel categoria)
        {
            var category = _mapper.Map<Categoria>(categoria);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao remover");
            }

            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id);
            var category = _mapper.Map<CategoriaViewModel>(categoria);

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(CategoriaViewModel categoria)
        {

            var category = _mapper.Map<Categoria>(categoria);

            _context.Categorias.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        /*[HttpGet]
        public IActionResult Cadastro(int? id)
        {

            CategoriaViewModel categoryView = new CategoriaViewModel();

            if (id != null)
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
                categoryView.Id = categoria.Id;
                categoryView.Nome = categoria.Nome;
            }

            return View(categoryView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var category = new Categoria
                {
                    Id = (categoria.Id != null) ? (int)categoria.Id : 0,
                    Nome = categoria.Nome
                };

                if(category.Id == null)
                {
                    _context.Categorias.Add(category);
                }
                else
                {
                    _context.Entry(category).State = EntityState.Modified;
                }

                _context.SaveChanges();

            }
            else
            {
                return View(categoria);
            }

            return RedirectToAction(nameof(Index));
        }*/
    }
}
