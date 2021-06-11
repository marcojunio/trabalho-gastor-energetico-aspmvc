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
    public class ParametroService
    {
        private readonly DbContextMge _dbContext;
        private readonly IMapper _mapper;
        public ParametroService(DbContextMge dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Parametros.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Parametros.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ParametroViewModel Get(int id)
        {
            var entity = _dbContext.Parametros.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<ParametroViewModel>(entity);
        }

        public IEnumerable<ParametroViewModel> GetAll()
        {
            var list = _dbContext.Parametros.ToList();
            if (list == null)
                return new ParametroViewModel[] { };

            return _mapper.Map<IEnumerable<ParametroViewModel>>(list);
        }

        public void Insert(ParametroViewModel obj)
        {
            var entity = _mapper.Map<Parametro>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(ParametroViewModel obj)
        {
            var entity = _mapper.Map<Parametro>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
