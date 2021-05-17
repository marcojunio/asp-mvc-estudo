using Atividade.Models.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Access
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [Display(Name = "Last Login")]
        public ICollection<LastLoginRegister> LastLogin { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
