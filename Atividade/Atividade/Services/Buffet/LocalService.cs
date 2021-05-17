using Atividade.Data;
using Atividade.Models.Buffet;
using Atividade.ViewModel.Buffet;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Services.Buffet
{
    public class LocalService : IGenericMethods<LocalViewModel>
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public LocalService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Locals.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Locals.Remove(entity);
            _dbContext.SaveChanges();
        }

        public LocalViewModel Get(Guid id)
        {
            var entity = _dbContext.Locals.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<LocalViewModel>(entity);
        }

        public IEnumerable<LocalViewModel> GetAll()
        {
            var list = _dbContext.Locals.ToList();
            if (list == null)
                return new LocalViewModel[] { };

            return _mapper.Map<IEnumerable<LocalViewModel>>(list);
        }

        public void Insert(LocalViewModel obj)
        {
            var entity = _mapper.Map<Local>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<LocalViewModel> GetByNameCity(string nameCity) 
        {
            var list = _dbContext.Locals.Where(x => x.City.Contains(nameCity)).ToList();

            if (list == null || nameCity == null)
                return GetAll();

            return _mapper.Map<IEnumerable<LocalViewModel>>(list);
        }
        public void Update(LocalViewModel obj)
        {
            var entity = _mapper.Map<Local>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
