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
    public class EventService : IGenericMethods<EventViewModel>
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public EventService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Events.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Events.Remove(entity);
            _dbContext.SaveChanges();
        }

        public EventViewModel Get(Guid id)
        {
            var entity = _dbContext.Events.
               Where(x => x.Id == id).
               Include(x => x.Client).
               Include(x => x.Local).
               Include(x => x.SituationEvent).
               Include(x => x.TypeEvent).
               FirstOrDefault();

            if (entity == null)
                return null;

            return _mapper.Map<EventViewModel>(entity);
        }

        public IEnumerable<EventViewModel> GetByDescrition(string descrition)
        {
            var list = _dbContext.Events.Where(x => x.Descrition.Contains(descrition)).
               Include(x => x.Client).
               Include(x => x.Local).
               Include(x => x.SituationEvent).
               Include(x => x.TypeEvent).
               ToList();

            if (list == null || descrition == null)
                return GetAll();

            return _mapper.Map<IEnumerable<EventViewModel>>(list);
        }


        public IEnumerable<EventViewModel> GetAll()
        {
            var list = _dbContext.Events.
                Include(x => x.Client).
                Include(x => x.Local).
                Include(x => x.SituationEvent).
                Include(x => x.TypeEvent).
                ToList();

            if (list == null)
                return new EventViewModel[] { };

            return _mapper.Map<IEnumerable<EventViewModel>>(list);
        }

        public void Insert(EventViewModel obj)
        {
            var entity = _mapper.Map<Event>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(EventViewModel obj)
        {
            var entity = _mapper.Map<Event>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
