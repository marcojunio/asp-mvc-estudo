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
        public async Task<RedirectResult> Login(LoginViewModel request)
        {
            if (request.Email == null)
            {
                TempData["msg-login"] = "Please insert your e-mail";
                return Redirect("/Account/Login");
            }

            if (request.Password == null)
            {
                TempData["msg-login"] = "Please insert you password";
                return Redirect("/Account/Login");
            }


            try
            {
                await _accessService.AuthenticatedUser(request.Email, request.Password);
                return Redirect("/User/Manage");
            }
            catch (Exception ex)
            {
                TempData["msg-login"] = ex.Message;
                return Redirect("/Account/Login");
            }
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Register(RegisterViewModel request)
        {
            if (request.Email == null)
            {
                TempData["msg-register"] = "Please insert your e-mail";
                return RedirectToAction("Register");
            }

            if (request.Password == null)
            {
                TempData["msg-register"] = "Please insert you password";
                return RedirectToAction("Register");
            }

            if (request.ConfirmPassword != request.Password)
            {
                TempData["msg-register"] = "Passwords differs";
                return RedirectToAction("Register");
            }

            try
            {
                await _accessService.RegisterUsuario(request.Email, request.Password);
                TempData["msg-register"] = "Register Successful";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["error-register"] = ex.Message;
                return RedirectToAction("Register");
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();
            viewModel.Message = (string)TempData["msg-login"];

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();

            viewModel.Message = (string)TempData["msg-register"];

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

        public bool isAuthenticated()
        {
            return true;
        }
    }
}
