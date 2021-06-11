using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoWatts { get; set; }
        public int? HorasUsoDiario { get; set; }

    }
}
