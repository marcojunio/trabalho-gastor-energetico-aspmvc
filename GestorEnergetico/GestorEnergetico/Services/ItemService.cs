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
    public class ItemService
    {
        private readonly DbContextMge _dbContext;
        private readonly IMapper _mapper;
        public ItemService(DbContextMge dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Itens.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Itens.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ItemViewModel Get(Guid id)
        {
            var entity = _dbContext.Itens.Where(x => x.Id == id).Include(x => x.Categoria).FirstOrDefault();
            
            if (entity == null)
                return null;

            return _mapper.Map<ItemViewModel>(entity);
        }

        public IEnumerable<ItemViewModel> GetAll()
        {
            var list = _dbContext.Itens.Include(x => x.Categoria).ToList();
            if (list == null)
                return new ItemViewModel[] { };

            return _mapper.Map<IEnumerable<ItemViewModel>>(list);
        }

        public void Insert(ItemViewModel obj)
        {
            var entity = _mapper.Map<Item>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(ItemViewModel obj)
        {
            var entity = _mapper.Map<Item>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

