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
    public class GuestService : IGenericMethods<GuestViewModel>
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public GuestService(BuffetDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Guests.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Guests.Remove(entity);
            _dbContext.SaveChanges();
        }

        public GuestViewModel Get(Guid id)
        {
            var entity = _dbContext.Guests.Where(x => x.Id == id).
                Include(x => x.Event).
                Include(x => x.GuestSituation).
                FirstOrDefault();

            if (entity == null)
                return null;

            return _mapper.Map<GuestViewModel>(entity);
        }

        public IEnumerable<GuestViewModel> GetAll()
        {
            var list = _dbContext.Guests.
                Include(x => x.Event).
                Include(x => x.GuestSituation).ToList();

            if (list == null)
                return new GuestViewModel[] { };

            return _mapper.Map<IEnumerable<GuestViewModel>>(list);
        }

        public void Insert(GuestViewModel obj)
        {
            var entity = _mapper.Map<Guest>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<GuestViewModel> GetByName(string nameGuest)
        {
            var list = _dbContext.Guests.Where(x => x.Name.Contains(nameGuest)).
                Include(x => x.Event).
                Include(x => x.GuestSituation).
                ToList();

            if (list == null || nameGuest == null)
                return GetAll();

            return _mapper.Map<IEnumerable<GuestViewModel>>(list);
        }

        public void Update(GuestViewModel obj)
        {
            var entity = _mapper.Map<Guest>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
