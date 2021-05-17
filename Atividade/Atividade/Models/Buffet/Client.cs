using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Models.Buffet
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
