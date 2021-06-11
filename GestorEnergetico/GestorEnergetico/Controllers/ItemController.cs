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

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }
    }
}
