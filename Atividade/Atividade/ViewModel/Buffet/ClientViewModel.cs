using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Buffet
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF is required.")]
        public string CPF { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
