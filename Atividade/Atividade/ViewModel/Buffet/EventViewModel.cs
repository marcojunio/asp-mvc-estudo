using Atividade.Models.Buffet;
using Atividade.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Buffet
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Descrition { get; set; }
        [Display(Name = "Client")]
        public Client Client { get; set; }
        [Display(Name = "Local")]
        public Local Local { get; set; }
        public string Observation { get; set; }
        public DateTime DayStart { get; set; }
        [Display(Name = "Type Event")]
        public TypeEvent TypeEvent { get; set; }
        [Display(Name = "Situation Event")]
        public SituationEvent SituationEvent { get; set; }
    }
}
