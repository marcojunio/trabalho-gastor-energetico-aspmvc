using GestorEnergetico.Data;
using GestorEnergetico.Services;
using GestorEnergetico.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly CategoriaService _categoriaService;
        private readonly DbContextMge _dbContext;

        public CategoriaController(
            ILogger<CategoriaController> logger,
            CategoriaService categoriaService,
            DbContextMge dbContextMge)
        {
            _dbContext = dbContextMge;
            _logger = logger;
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var list = _categoriaService.GetAll();

            return View(list);
        }

        public IActionResult Editar(int id)
        {
            var viewModel = _categoriaService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, CategoriaViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    _categoriaService.Update(viewModel);

                    return Redirect("/Categoria");
                }
                return View("Editar", viewModel);
            }
            catch
            {
                return View("Editar", viewModel);
            }
        }

        public IActionResult Criar()
        {
            var categoria = new CategoriaViewModel();

            categoria.Categorias = _dbContext.Categorias.ToList();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Criar(CategoriaViewModel model)
        {

            if(model != null) 
            {
                var newCategoria = new CategoriaViewModel
                {
                    CategoriaPaiId = model.CategoriaPaiId,
                    Descricao = model.Descricao
                };

                _categoriaService.Insert(newCategoria);
            }

            return Redirect("Index");
        }

        public IActionResult Detalhe(int id)
        {
            var categoria = _categoriaService.Get(id);
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Deletar(int id) 
        {
            var categoria = _categoriaService.Get(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Deletar(int id, IFormCollection collection)
        {
            _categoriaService.Delete(id);

            return Redirect("/Categoria");
        }
    }
}
