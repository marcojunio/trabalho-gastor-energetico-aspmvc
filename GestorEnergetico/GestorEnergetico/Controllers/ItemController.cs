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
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ItemService _itemService;
        private readonly DbContextMge _dbContextMge;
        public ItemController(ILogger<ItemController> logger,ItemService itemService,DbContextMge dbContextMge)
        {
            _dbContextMge = dbContextMge;
            _itemService = itemService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var itens = _itemService.GetAll();

            return View(itens);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            var itemViewModel = new ItemViewModel();
            itemViewModel.Categorias = _dbContextMge.Categorias.ToList();

            return View(itemViewModel);
        }

        public IActionResult Editar(Guid id)
        {
            var viewModel = _itemService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ItemViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    _itemService.Update(viewModel);

                    return Redirect("/Item");
                }
                return View("Editar", viewModel);
            }
            catch
            {
                return View("Editar", viewModel);
            }
        }

        [HttpPost]
        public IActionResult Criar(ItemViewModel model)
        {

            if (ModelState.IsValid)
            {
                var categoria = _dbContextMge.Categorias.Find(model.IdCategoria);

                var novoItem = new ItemViewModel
                {
                    Id = new Guid(),
                    Descricao = model.Descricao,
                    Categoria = categoria,
                    DataFabricacao = model.DataFabricacao,
                    HorasUsoDiario = model.HorasUsoDiario,
                    ConsumoWatts = model.ConsumoWatts,
                    Nome = model.Nome
                };

                _itemService.Insert(novoItem);
            }

            return Redirect("Index");
        }


        public IActionResult Detalhe(Guid id)
        {
            var categoria = _itemService.Get(id);
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Deletar(Guid id)
        {
            var categoria = _itemService.Get(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Deletar(Guid id, IFormCollection collection)
        {
            _itemService.Delete(id);

            return Redirect("/Item");
        }
    }
}
