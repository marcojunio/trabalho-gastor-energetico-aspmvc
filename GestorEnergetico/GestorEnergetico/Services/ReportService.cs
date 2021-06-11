using GestorEnergetico.Data;
using GestorEnergetico.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Services
{
    public class ReportService
    {
        private DbContextMge _dbContext;

        public ReportService(DbContextMge dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TotalConsumoEnergiaDto> GerarTotalConsumo()
        {
            var totalConsumoList = new List<TotalConsumoEnergiaDto>();

            var items = _dbContext.Itens.ToList();
            var parametrosDb = _dbContext.Parametros.FirstOrDefault();

            foreach (var item in items)
            {
                var itemSendoCalculado = new TotalConsumoEnergiaDto();
                var dataAtual = DateTime.Now;
                var diasDoMes = DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);

                itemSendoCalculado.nomeItem = item.Nome;
                itemSendoCalculado.TotalWatts = (decimal)(item.ConsumoWatts / 1000 * item.HorasUsoDiario * diasDoMes);
                itemSendoCalculado.ValorEmReais = (double)(itemSendoCalculado.TotalWatts * parametrosDb.ValorKwh * diasDoMes);

                if (itemSendoCalculado.TotalWatts < parametrosDb.FaixaConsumoMedio)
                {
                    itemSendoCalculado.IndicadorDeConsumo = "Baixo";
                }
                else if (itemSendoCalculado.TotalWatts > parametrosDb.FaixaConsumoAlto)
                {
                    itemSendoCalculado.IndicadorDeConsumo = "Alto";
                }
                else
                {
                    itemSendoCalculado.IndicadorDeConsumo = "Médio";
                }

                totalConsumoList.Add(itemSendoCalculado);
            }

            return totalConsumoList;
        }

        public IEnumerable<ItensConsumoDto> ItensQueMaisConsome()
        {
            var itens = _dbContext.Itens.ToList();
            var itensQueMaisConsome = new List<ItensConsumoDto>();

            var dataAtual = DateTime.Now;
            var diasDoMes = DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);

            foreach (var item in itens)
            {
                var itemQueMaisConsome = new ItensConsumoDto();

                itemQueMaisConsome.NomeItem = item.Nome;
                itemQueMaisConsome.QuantidadeConsumoMensal = (decimal)(item.ConsumoWatts / 1000 * item.HorasUsoDiario * diasDoMes);

                itensQueMaisConsome.Add(itemQueMaisConsome);
            }

            var itensFinais = itensQueMaisConsome.OrderByDescending(x => x.QuantidadeConsumoMensal).Take(5);

            return itensFinais;
        }


        public IEnumerable<CategoriasConsumoDto> CategoriasQueMaisConsome()
        {
            var itens = _dbContext.Itens.Include(x => x.Categoria).ToList();
            var itensQueMaisConsome = new List<CategoriasConsumoDto>();

            var dataAtual = DateTime.Now;
            var diasDoMes = DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);

            foreach (var item in itens)
            {
                var itemQueMaisConsome = new CategoriasConsumoDto();

                itemQueMaisConsome.NomeCategoria = item.Categoria.Descricao;
                itemQueMaisConsome.QuantidadeConsumoMensal += (decimal)(item.ConsumoWatts / 1000 * item.HorasUsoDiario * diasDoMes);

                itensQueMaisConsome.Add(itemQueMaisConsome);
            }

            var itensFinais = itensQueMaisConsome.OrderByDescending(x => x.QuantidadeConsumoMensal).Take(5);

            return itensFinais.Distinct(new CompareNomeCategoria());
        }
    }

    public class CompareNomeCategoria : IEqualityComparer<CategoriasConsumoDto>
    {
        public bool Equals(CategoriasConsumoDto x, CategoriasConsumoDto y)
        {
            if (x.NomeCategoria == y.NomeCategoria)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] CategoriasConsumoDto obj)
        {
            return 0;
        }
    }
}
