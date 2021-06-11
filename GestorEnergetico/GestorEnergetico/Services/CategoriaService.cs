using AutoMapper;
using GestorEnergetico.Data;
using GestorEnergetico.Models;
using GestorEnergetico.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEnergetico.Services
{
    public class CategoriaService
    {
        private readonly DbContextMge _dbContext;
        private readonly IMapper _mapper;
        public CategoriaService(DbContextMge dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Categorias.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Categorias.Remove(entity);
            _dbContext.SaveChanges();
        }

        public CategoriaViewModel Get(int id)
        {
            var entity = _dbContext.Categorias.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<CategoriaViewModel>(entity);
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            var list = _dbContext.Categorias.ToList();
            if (list == null)
                return new CategoriaViewModel[] { };

            return _mapper.Map<IEnumerable<CategoriaViewModel>>(list);
        }

        public void Insert(CategoriaViewModel obj)
        {
            var entity = _mapper.Map<Categoria>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(CategoriaViewModel obj)
        {
            var entity = _mapper.Map<Categoria>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

