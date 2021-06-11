using GestorEnergetico.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.ViewModel
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome requerido")]
        public string Nome{ get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição requerida")]
        public string Descricao { get; set; }
        [Display(Name = "Data de Fabricação")]
        [Required(ErrorMessage = "Data de fabricação requerida")]
        public DateTime DataFabricacao { get; set; }
        [Display(Name = "Consumo em Watts")]
        [Required(ErrorMessage = "Consumo em Watts requerida")]
        public decimal ConsumoWatts { get; set; }
        [Display(Name = "Horas de Uso")]
        [Required(ErrorMessage = "Horas de Uso requerida")]
        public int? HorasUsoDiario { get; set; }
        public List<Categoria> Categorias { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
