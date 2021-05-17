using Atividade.Data;
using Atividade.RequestModel;
using Atividade.Services.Buffet;
using Atividade.ViewModel.Buffet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Controllers.User
{
    [Authorize]
    [Route("User/{controller}/{action}/{id?}")]
    public class GuestController : ViewHelper
    {
        private readonly GuestService _guestService;
        private readonly BuffetDbContext _buffetDbContext;

        public GuestController(BuffetDbContext buffetDbContext, GuestService guestService)
        {
            _buffetDbContext = buffetDbContext;
            _guestService = guestService;
        }

        public IActionResult All()
        {
            var list = _guestService.GetAll();
            return View(NameView(), list);
        }

        [HttpPost]
        public IActionResult Search(string nameGuest)
        {
            var list = _guestService.GetByName(nameGuest);
            return View("~/Views/User/Guest/All.cshtml", list);
        }

        public IActionResult Create()
        {
            var vm = new GuestRequestModel();

            vm.Events = _buffetDbContext.Events.ToList();
            vm.GuestSituations = _buffetDbContext.GuestSituations.ToList();

            return View(NameView(),vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuestRequestModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var events = _buffetDbContext.Events.Where(x => x.Id == viewModel.IdEvent).FirstOrDefault();
                    var situation = _buffetDbContext.GuestSituations.Where(x => x.Id == viewModel.IdSituationGuest).FirstOrDefault();

                    var guest = new GuestViewModel
                    {
                        Document = viewModel.Document,
                        GuestSituation = situation,
                        Event = events,
                        Name = viewModel.Name
                    };

                    _guestService.Insert(guest);
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
            var viewModel = _guestService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _guestService.Get(id);
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
                    _guestService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _guestService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _guestService.Get(id);
                return View(NameView(), viewModel);
            }
        }
    }
}

