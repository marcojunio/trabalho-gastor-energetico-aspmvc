using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models.Dto
{
    public class CategoriasConsumoDto
    {
        public string NomeCategoria { get; set; }
        public decimal QuantidadeConsumoMensal { get; set; }
    }
}
