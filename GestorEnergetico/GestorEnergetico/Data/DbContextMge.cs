using GestorEnergetico.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Data
{
    public class DbContextMge : DbContext
    {
        public DbContextMge(DbContextOptions<DbContextMge> options) : base(options) 
        {

        }

        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Item> Itens{ get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
