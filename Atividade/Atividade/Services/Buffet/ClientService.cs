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
    public class ClientService : IGenericMethods<ClientViewModel>
    {
        private readonly BuffetDbContext _dbContext;
        private readonly IMapper _mapper;
        public ClientService(BuffetDbContext dbContext,IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Clients.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Clients.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ClientViewModel Get(Guid id)
        {
            var entity = _dbContext.Clients.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<ClientViewModel>(entity);
        }

        public IEnumerable<ClientViewModel> GetByName(string nameClient)
        {
            var list = _dbContext.Clients.Where(x => x.Name.Contains(nameClient)).ToList();

            if (list == null || nameClient == null)
                return GetAll();

            return _mapper.Map<IEnumerable<ClientViewModel>>(list);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var list = _dbContext.Clients.ToList();
            if (list == null)
                return new ClientViewModel[] { };

            return _mapper.Map<IEnumerable<ClientViewModel>>(list);
        }

        public void Insert(ClientViewModel obj)
        {
            obj.Id = new Guid();
            var entity = _mapper.Map<Client>(obj);

            _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Update(ClientViewModel obj)
        {
            var entity = _mapper.Map<Client>(obj);

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
