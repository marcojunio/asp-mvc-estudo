using Atividade.Services.Type;
using Atividade.ViewModel.Types;
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
    public class GuestSituationController : ViewHelper
    {
        private readonly GuestSituationService _guestSituationService;

        public GuestSituationController(GuestSituationService guestSituationService)
        {
            _guestSituationService = guestSituationService;
        }

        public IActionResult All()
        {
            var list = _guestSituationService.GetAll();
            return View(NameView(), list);
        }

        public IActionResult Edit(Guid id)
        {
            var viewModel = _guestSituationService.Get(id);
            return View(NameView(), viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, GuestSituationViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _guestSituationService.Update(viewModel);

                    return RedirectToAction(nameof(All));
                }
                return View(NameView(), viewModel);
            }
            catch
            {
                return View(NameView(), viewModel);
            }
        }

        public IActionResult Create()
        {
            return View(NameView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuestSituationViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _guestSituationService.Insert(viewModel);
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
            var viewModel = _guestSituationService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _guestSituationService.Get(id);
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
                    _guestSituationService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _guestSituationService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _guestSituationService.Get(id);
                return View(NameView(), viewModel);
            }
        }
    }
}
