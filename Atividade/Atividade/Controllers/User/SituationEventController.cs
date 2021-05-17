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
    public class SituationEventController : ViewHelper
    {
        private readonly SituationEventService _situationEventService;

        public SituationEventController(SituationEventService situationEventService)
        {
            _situationEventService = situationEventService;
        }

        public IActionResult All()
        {
            var list = _situationEventService.GetAll();
            return View(NameView(), list);
        }

        public IActionResult Edit(Guid id)
        {
            var viewModel = _situationEventService.Get(id);
            return View(NameView(), viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SituationEventViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _situationEventService.Update(viewModel);

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
        public ActionResult Create(SituationEventViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _situationEventService.Insert(viewModel);
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
            var viewModel = _situationEventService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _situationEventService.Get(id);
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
                    _situationEventService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _situationEventService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _situationEventService.Get(id);
                return View(NameView(), viewModel);
            }
        }
    }
}
