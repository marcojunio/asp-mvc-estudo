using Atividade.Models.Access;
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
    }
}
