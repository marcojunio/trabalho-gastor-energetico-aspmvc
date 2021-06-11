using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models.Dto
{
    public class ItensConsumoDto
    {
        public string NomeItem { get; set; }
        public decimal QuantidadeConsumoMensal { get; set; }
    }
}
