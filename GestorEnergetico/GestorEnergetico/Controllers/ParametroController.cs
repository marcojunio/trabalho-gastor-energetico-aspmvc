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

        public ParametroController(ILogger<ParametroController> logger)
        {
            _logger = logger;
        }
    }
}
