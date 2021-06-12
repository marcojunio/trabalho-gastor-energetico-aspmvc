using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Models.Dto
{
    public class DashboardDto
    {
        public decimal TotalConsumoKwh { get; set; }
        public double TotalEmReais { get; set; }
        public DateTime DataAtual { get; set; }
    }
}
