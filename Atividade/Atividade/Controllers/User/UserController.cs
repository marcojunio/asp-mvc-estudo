using Atividade.Models;
using Atividade.Services;
using Atividade.ViewModel.Access;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Atividade.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly AccessService _accessService;
        public UserController(AccessService accessService)
        {
            _accessService = accessService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            var userEmail = HttpContext.User.Identity.Name;
            var user = _accessService.GetUser(userEmail);

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Address = user.Address,
                Age = user.Age,
                Cpf = user.Cpf,
                Email = user.Email,
                Name = user.Name,
                LastLogin = user.LastLoginRegisters
            };

            return View(userViewModel);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string password,string newPassword,Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accessService.UpdatePassword(id, password, newPassword);

                    return RedirectToAction("Logout", "Account");
                }
                return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
          
        }


        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
