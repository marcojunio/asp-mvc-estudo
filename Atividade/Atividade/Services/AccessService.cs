using Atividade.Models.Access;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.Services
{
    public class AccessService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccessService(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AuthenticatedUser(string email,string password)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!resultado.Succeeded)
            {
                throw new Exception("Email or password invalid please check your credentials.");
            }

        }
        public async Task RegisterUsuario(string email,string senha)
        {
            var novoUsuario = new User()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(novoUsuario,senha);

            if (!resultado.Succeeded)
            {
                throw new Exception("Erro geral");
            }
        }
    }
}
