using GestorEnergetico.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Core
{
    public class ConfigurationService
    {
        public static void ConfigureServicesDi(IServiceCollection services) 
        {
            services.AddTransient<CategoriaService>();
            services.AddTransient<ItemService>();
            services.AddTransient<ParametroService>();
            services.AddTransient<ReportService>();
        }
    }
}
