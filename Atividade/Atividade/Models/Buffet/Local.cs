using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Buffet
{
    public class Local
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
    }
}
