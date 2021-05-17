using Atividade.Data;
using Atividade.RequestModel;
using Atividade.Services.Buffet;
using Atividade.Services.Type;
using Atividade.ViewModel.Buffet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Controllers.User
{
    [Authorize]
    [Route("User/{controller}/{action}/{id?}")]
    public class EventController : ViewHelper
    {
        private readonly EventService _eventService;
        private readonly BuffetDbContext _buffetDbContext;

        public EventController(BuffetDbContext buffetDbContext, EventService eventService)
        {
            _buffetDbContext = buffetDbContext;
            _eventService = eventService;
        }

        public IActionResult All()
        {
            var list = _eventService.GetAll();
            return View(NameView(), list);
        }

        [HttpPost]
        public IActionResult Search(string descrition)
        {
            var list = _eventService.GetByDescrition(descrition);
            return View("~/Views/User/Event/All.cshtml", list);
        }

        public IActionResult Create()
        {
            var vm = new EventRequestModel();

            vm.Clients = _buffetDbContext.Clients.ToList();
            vm.SituationEvents = _buffetDbContext.SituationEvents.ToList();
            vm.TypeEvents = _buffetDbContext.TypeEvents.ToList();
            vm.Locals = _buffetDbContext.Locals.ToList();

            return View(NameView(),vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventRequestModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _buffetDbContext.Clients.Where(x => x.Id == viewModel.IdClient).FirstOrDefault();
                    var type = _buffetDbContext.TypeEvents.Where(x => x.Id == viewModel.IdTypeEvent).FirstOrDefault();
                    var local = _buffetDbContext.Locals.Where(x => x.Id == viewModel.IdLocal).FirstOrDefault();
                    var situation = _buffetDbContext.SituationEvents.Where(x => x.Id == viewModel.IdSituationEvent).FirstOrDefault();

                    var evetViewModel = new EventViewModel
                    {
                        Client = client,
                        Local = local,
                        TypeEvent = type,
                        SituationEvent = situation,
                        Observation = viewModel.Observation,
                        Descrition = viewModel.Descrition,
                        DayStart = viewModel.DayStart
                    };

                    _eventService.Insert(evetViewModel);
                    return RedirectToAction(nameof(All));
                }
                return View(NameView(), viewModel);
            }
            catch
            {
                return View(NameView(), viewModel);
            }
        }

        public IActionResult Details(Guid id)
        {
            var viewModel = _eventService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _eventService.Get(id);
            return View(NameView(), viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eventService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _eventService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _eventService.Get(id);
                return View(NameView(), viewModel);
            }
        }
    }
}
