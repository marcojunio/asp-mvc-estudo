using Atividade.Models.Buffet;
using Atividade.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.RequestModel
{
    public class EventRequestModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Type Event")]
        [Required(ErrorMessage = "Type Event is required.")]
        public Guid IdTypeEvent { get; set; }
        [Display(Name = "Local")]
        [Required(ErrorMessage = "Local is required.")]
        public Guid IdLocal { get; set; }
        [Display(Name = "Client")]
        [Required(ErrorMessage = "Client is required.")]
        public Guid IdClient { get; set; }
        [Display(Name = "Situation")]
        [Required(ErrorMessage = "Situation is required.")]
        public Guid IdSituationEvent { get; set; }
        [Display(Name = "Descrition")]
        [Required(ErrorMessage = "Descrition is required.")]
        public string Descrition { get; set; }
        [Display(Name = "Observation")]
        [Required(ErrorMessage = "Descrition is required.")]
        public string Observation { get; set; }
        [Display(Name = "Day Start")]
        [Required(ErrorMessage = "Day Start is required.")]
        public DateTime DayStart { get; set; }

        public IEnumerable<TypeEvent> TypeEvents { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Local> Locals { get; set; }
        public IEnumerable<SituationEvent> SituationEvents { get; set; }
    }
}
