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
    public class GuestSituationService
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public GuestSituationService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.GuestSituations.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.GuestSituations.Remove(entity);
            _dbContext.SaveChanges();
        }

        public GuestSituationViewModel Get(Guid id)
        {
            var entity = _dbContext.GuestSituations.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<GuestSituationViewModel>(entity);
        }

        public IEnumerable<GuestSituationViewModel> GetAll()
        {
            var list = _dbContext.GuestSituations.ToList();
            if (list == null)
                return new GuestSituationViewModel[] { };

            return _mapper.Map<IEnumerable<GuestSituationViewModel>>(list);
        }

        public void Insert(GuestSituationViewModel obj)
        {
            var entity = _mapper.Map<GuestSituation>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(GuestSituationViewModel obj)
        {
            var entity = _mapper.Map<SituationEvent>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
