using Atividade.Services.Buffet;
using Atividade.ViewModel.Buffet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Atividade.Controllers.User
{
    [Authorize]
    [Route("User/{controller}/{action}/{id?}")]
    public class LocalController : ViewHelper
    {
        private readonly LocalService _localService;

        public LocalController(LocalService localService)
        {
            _localService = localService;
        }

        public IActionResult All()
        {
            var list = _localService.GetAll();
            return View(NameView(), list);
        }

        [HttpPost]
        public IActionResult Search(string nameCity)
        {
            var list = _localService.GetByNameCity(nameCity);
            return View("~/Views/User/Local/All.cshtml", list);
        }

        public IActionResult Edit(Guid id)
        {
            var viewModel = _localService.Get(id);
            return View(NameView(), viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, LocalViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _localService.Update(viewModel);

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
        public ActionResult Create(LocalViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _localService.Insert(viewModel);
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
            var viewModel = _localService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _localService.Get(id);
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
                    _localService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _localService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _localService.Get(id);
                return View(NameView(), viewModel);
            }
        }

    }
}
