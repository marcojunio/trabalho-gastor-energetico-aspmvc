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
    public class ParametroController : Controller
    {
        private readonly ILogger<ParametroController> _logger;
        private readonly ParametroService _parametroService;

        public ParametroController(ILogger<ParametroController> logger,ParametroService parametroService)
        {
            _parametroService = parametroService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var itens = _parametroService.GetAll();

            return View(itens);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var viewModel = _parametroService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, ParametroViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    _parametroService.Update(viewModel);

                    return Redirect("/Parametro");
                }
                return View("Editar", viewModel);
            }
            catch
            {
                return View("Editar", viewModel);
            }
        }

        [HttpPost]
        public IActionResult Criar(ParametroViewModel model)
        {

            if (ModelState.IsValid)
            {
                var novoItem = new ParametroViewModel
                {
                    FaixaConsumoAlto = model.FaixaConsumoAlto,
                    FaixaConsumoMedio = model.FaixaConsumoMedio,
                    ValorKwh = model.ValorKwh
                };

                _parametroService.Insert(novoItem);
            }

            return Redirect("Index");
        }


        public IActionResult Detalhe(int id)
        {
            var categoria = _parametroService.Get(id);
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var categoria = _parametroService.Get(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Deletar(int id, IFormCollection collection)
        {
            _parametroService.Delete(id);

            return Redirect("/Parametro");
        }
    }
}
