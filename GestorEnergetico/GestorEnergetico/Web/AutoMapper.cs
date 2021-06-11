using AutoMapper;
using GestorEnergetico.Models;
using GestorEnergetico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Web
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemViewModel, Item>();

            CreateMap<Parametro, ParametroViewModel>();
            CreateMap<ParametroViewModel, Parametro>();

            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}
