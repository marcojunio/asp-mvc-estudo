using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Buffet
{
    public class LocalViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Display(Name = "Number")]
        [Required(ErrorMessage = "Number is required.")]
        public int Number { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}
