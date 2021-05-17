using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Types
{
    public class GuestSituationViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Descrition")]
        [Required(ErrorMessage = "Descrition required")]
        public string Descrition { get; set; }

    }
}
