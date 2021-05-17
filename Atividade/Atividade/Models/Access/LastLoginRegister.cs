using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Access
{
    public class LastLoginRegister
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
