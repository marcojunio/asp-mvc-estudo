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
    public class ClientController : ViewHelper
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult All()
        {
            var list = _clientService.GetAll();
            return View(NameView(), list);
        }

        public IActionResult Edit(Guid id)
        {
            var viewModel = _clientService.Get(id);
            return View(NameView(),viewModel);
        }

        [HttpPost]
        public IActionResult Search(string nameClient)
        {
            var list = _clientService.GetByName(nameClient);
            return View("~/Views/User/Client/All.cshtml", list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientService.Update(viewModel);

                    return RedirectToAction(nameof(All));
                }
                return View(NameView(),viewModel);
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
        public ActionResult Create(ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientService.Insert(viewModel);
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
            var viewModel = _clientService.Get(id);
            return View(NameView(), viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var viewModel = _clientService.Get(id);
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
                    _clientService.Delete(id);

                    return RedirectToAction(nameof(All));
                }

                var viewModel = _clientService.Get(id);
                return View(NameView(), viewModel);
            }
            catch
            {
                var viewModel = _clientService.Get(id);
                return View(NameView(), viewModel);
            }
        }
    }
}
