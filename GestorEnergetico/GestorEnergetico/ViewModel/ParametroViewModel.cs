using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.ViewModel
{
    public class ParametroViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Valor Kwh")]
        [Required(ErrorMessage = "Valor Kwh requerido")]
        public decimal ValorKwh { get; set; }
        [Display(Name = "Faixa de Consumo Alto")]
        [Required(ErrorMessage = "Faixa de consumo alto requerido")]
        public decimal FaixaConsumoAlto { get; set; }
        [Display(Name = "Faixa de Consumo Medio")]
        [Required(ErrorMessage = "Faixa de consumo baixo requerido")]
        public decimal FaixaConsumoMedio { get; set; }
    }
}
