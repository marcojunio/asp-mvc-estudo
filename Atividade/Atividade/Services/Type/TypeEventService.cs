using Atividade.Data;
using Atividade.Models.Buffet;
using Atividade.Models.Types;
using Atividade.ViewModel.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Services.Type
{
    public class TypeEventService : IGenericMethods<TypeEventViewModel>
    {

        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public TypeEventService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.TypeEvents.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.TypeEvents.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TypeEventViewModel Get(Guid id)
        {
            var entity = _dbContext.TypeEvents.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<TypeEventViewModel>(entity);
        }

        public IEnumerable<TypeEventViewModel> GetAll()
        {
            var list = _dbContext.TypeEvents.ToList();
            if (list == null)
                return new TypeEventViewModel[] { };

            return _mapper.Map<IEnumerable<TypeEventViewModel>>(list);
        }

        public void Insert(TypeEventViewModel obj)
        {
            var entity = _mapper.Map<TypeEvent>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TypeEventViewModel obj)
        {
            var entity = _mapper.Map<TypeEvent>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
