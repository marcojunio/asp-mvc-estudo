using Atividade.Data;
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
    public class SituationEventService
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public SituationEventService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.SituationEvents.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.SituationEvents.Remove(entity);
            _dbContext.SaveChanges();
        }

        public SituationEventViewModel Get(Guid id)
        {
            var entity = _dbContext.SituationEvents.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<SituationEventViewModel>(entity);
        }

        public IEnumerable<SituationEventViewModel> GetAll()
        {
            var list = _dbContext.SituationEvents.ToList();
            if (list == null)
                return new SituationEventViewModel[] { };

            return _mapper.Map<IEnumerable<SituationEventViewModel>>(list);
        }

        public void Insert(SituationEventViewModel obj)
        {
            var entity = _mapper.Map<SituationEvent>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(SituationEventViewModel obj)
        {
            var entity = _mapper.Map<SituationEvent>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
