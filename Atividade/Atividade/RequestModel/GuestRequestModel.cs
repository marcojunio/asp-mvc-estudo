using Atividade.Models.Buffet;
using Atividade.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.RequestModel
{
    public class GuestRequestModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Guest Situation")]
        [Required(ErrorMessage = "Guest Situation is required.")]
        public Guid IdSituationGuest { get; set; }
        [Display(Name = "Event")]
        [Required(ErrorMessage = "Event Situation is required.")]
        public Guid IdEvent { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Document")]
        [Required(ErrorMessage = "Document is required.")]
        public string Document { get; set; }
        public IEnumerable<GuestSituation> GuestSituations { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
