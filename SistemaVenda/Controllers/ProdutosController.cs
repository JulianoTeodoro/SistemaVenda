using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DAL;
using Domain.Entidades;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;

namespace SistemaVenda.Controllers
{
    public class ProdutosController : Controller
    {
        protected IProdutoRepository _produtoRepository;
        protected ICategoriaRepository _categoriaRepository;
        protected readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var produtos = _produtoRepository.Get();

            var produtosView = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(produtosView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categorys = _categoriaRepository.Get();

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
                var categorys = _categoriaRepository.Get();
                var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

                var viewModel = new ProdutoFormViewModel { Categorias = categoryView };
                return View(viewModel);
            }

            var produto = _mapper.Map<Produto>(produtoView.Produto);
            _produtoRepository.Create(produto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var categorys = _categoriaRepository.Get();
            var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

            var produto = _produtoRepository.GetById(p => p.Id == id);
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
                var categorys = _categoriaRepository.Get();
                var categoryView = _mapper.Map<List<CategoriaViewModel>>(categorys);

                var viewModel = new ProdutoFormViewModel { Categorias = categoryView, Produto = produtoView.Produto };
                return View(viewModel);
            }

            var produto = _mapper.Map<Produto>(produtoView.Produto);

            _produtoRepository.Update(produto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var produto = _produtoRepository.GetById(p => p.Id == id);

            var produtoView = _mapper.Map<ProdutoViewModel>(produto);
            return View(produtoView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProdutoViewModel produtoView)
        {
            var produto = _mapper.Map<Produto>(produtoView);

            _produtoRepository.Delete(produto);

            return RedirectToAction(nameof(Index));

        }






    }
}
