using GestorEnergetico.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.ViewModel
{
    public class CategoriaViewModel
    {
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "Descrição requerida")]
        public string Descricao { get; set; }
        public int Id { get; set; }

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        public List<Categoria> Categorias { get; set; }
    }
}
