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

        public CategoriaController(ILogger<CategoriaController> logger)
        {
            _logger = logger;
        }

    }
}
