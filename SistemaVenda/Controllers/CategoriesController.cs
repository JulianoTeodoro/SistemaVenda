using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;
using Repositorio.Interfaces;

namespace SistemaVenda.Controllers
{
    public class CategoriesController : Controller
    {

        protected readonly ICategoriaRepository _categoriaRepository;
        protected readonly IMapper _mapper;

        public CategoriesController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categorias = _categoriaRepository.Get();

            var categoriaView = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);

            return View(categoriaView);
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

            _categoriaRepository.Create(category);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao editar");
            }

            var categoria = _categoriaRepository.GetById(p => p.Id == id);
            var category = _mapper.Map<CategoriaViewModel>(categoria);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaViewModel categoria)
        {
            var category = _mapper.Map<Categoria>(categoria);
            _categoriaRepository.Update(category);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int? id)
        {
            if (id is null)
            {
                return BadRequest("Erro ao remover");
            }

            var categoria = _categoriaRepository.GetById(p => p.Id == id);
            var category = _mapper.Map<CategoriaViewModel>(categoria);

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(CategoriaViewModel categoria)
        {

            var category = _mapper.Map<Categoria>(categoria);

            _categoriaRepository.Delete(category);
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
