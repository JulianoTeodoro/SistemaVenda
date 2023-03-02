using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.Controllers
{
    public class ProdutosController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ProdutosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var produtos = _context.Produtos.Include(p => p.Categoria).ToList();

            var produtosView = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(produtosView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categorys = _context.Categorias.ToList();

            var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

            var produtosView = new ProdutoFormViewModel
            {
                Categorias = categoryView
            };

            return View(produtosView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoFormViewModel produtoView)
        {
            if(!ModelState.IsValid)
            {
                var categorys = _context.Categorias.ToList();
                var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

                var viewModel = new ProdutoFormViewModel { Categorias = categoryView };
                return View(viewModel);
            }

            var produto = _mapper.Map<Produto>(produtoView.Produto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var categorys = _context.Categorias.ToList();
            var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            var produtoView = _mapper.Map<ProdutoViewModel>(produto);

            var viewModel = new ProdutoFormViewModel { Categorias = categoryView, Produto = produtoView };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProdutoFormViewModel produtoView)
        {
            if(!ModelState.IsValid)
            {
                var categorys = _context.Categorias.ToList();
                var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

                var viewModel = new ProdutoFormViewModel { Categorias = categoryView, Produto = produtoView.Produto };
                return View(viewModel);
            }

            var produto = _mapper.Map<Produto>(produtoView.Produto);

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            var produtoView = _mapper.Map<ProdutoViewModel>(produto);
            return View(produtoView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProdutoViewModel produtoView)
        {
            var produto = _mapper.Map<Produto>(produtoView);

            _context.Produtos.Remove(produto);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }






    }
}
