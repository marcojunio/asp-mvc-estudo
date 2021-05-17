using Atividade.Models.Access;
using Atividade.Models.Buffet;
using Atividade.Models.Types;
using Atividade.ViewModel.Access;
using Atividade.ViewModel.Buffet;
using Atividade.ViewModel.Types;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Web
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();

            CreateMap<Event, EventViewModel>();
            CreateMap<EventViewModel, Event>();

            CreateMap<Local, LocalViewModel>();
            CreateMap<LocalViewModel, Local>();

            CreateMap<TypeEvent, TypeEventViewModel>();
            CreateMap<TypeEventViewModel, TypeEvent>();

            CreateMap<Guest, GuestViewModel>();
            CreateMap<GuestViewModel, Guest>();

            CreateMap<SituationEvent, SituationEventViewModel>();
            CreateMap<SituationEventViewModel, SituationEvent>();

            CreateMap<GuestSituation, GuestSituationViewModel>();
            CreateMap<GuestSituationViewModel, GuestSituation>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
