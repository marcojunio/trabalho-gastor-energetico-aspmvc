using GestorEnergetico.Models;
using GestorEnergetico.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReportService _reportService;

        public HomeController(ILogger<HomeController> logger,ReportService reportService)
        {
            _reportService = reportService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dashboard = _reportService.preencherDashboard();

            return View(dashboard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TotalConsumo()
        {
            var total = _reportService.GerarTotalConsumo();

            return View(total);
        }

        public IActionResult ItensConsumo()
        {
            var itens = _reportService.ItensQueMaisConsome();

            return View(itens);
        }

        public IActionResult CategoriasConsumo()
        {
            var categorias = _reportService.CategoriasQueMaisConsome();

            return View(categorias);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
