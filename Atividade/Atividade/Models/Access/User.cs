using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Access
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            LastLoginRegisters = new List<LastLoginRegister>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public DateTime? LastLogin { get; set; }
        public ICollection<LastLoginRegister> LastLoginRegisters { get; set; }
    }
}
