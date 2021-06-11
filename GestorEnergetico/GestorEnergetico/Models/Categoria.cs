using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models
{
    public class Categoria
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaPaiId { get; set; }
    }
}
