using Atividade.Models.Access;
using Atividade.Models.Buffet;
using Atividade.Models.Types;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Data
{
    public class BuffetDbContext : IdentityDbContext<User, Role, Guid>
    {
        public BuffetDbContext(DbContextOptions<BuffetDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients{get;set;}
        public DbSet<Event>  Events { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<TypeEvent> TypeEvents { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<SituationEvent> SituationEvents{ get; set; }
        public DbSet<GuestSituation> GuestSituations { get; set; }
        public DbSet<LastLoginRegister> LastLoginRegisters { get; set; }
    }
}
