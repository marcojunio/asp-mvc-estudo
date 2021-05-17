using Atividade.Models;
using Atividade.Services;
using Atividade.ViewModel.Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Atividade.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccessService _accessService;

        public AccountController(ILogger<HomeController> logger, AccessService accessService)
        {
            _accessService = accessService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _accessService.AuthenticatedUser(model.Email, model.Password);
                    return Redirect("/User");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accessService.RegisterUsuario(viewModel);
                    return RedirectToAction("Login");
                }

                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }

        }

        public async Task<IActionResult> Logout()
        {
            await _accessService.Logout();
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new RegisterUserViewModel();
            return View(viewModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool IsAuthenticated()
        {
            return true;
        }
    }
}
