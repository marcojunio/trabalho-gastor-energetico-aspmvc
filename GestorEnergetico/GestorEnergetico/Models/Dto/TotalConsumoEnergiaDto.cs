using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models.Dto
{
    public class TotalConsumoEnergiaDto
    {
        public string NomeItem { get; set; }
        public decimal TotalWatts { get; set; }
        public double ValorEmReais { get; set; }
        public string IndicadorDeConsumo { get; set; }
    }
}
