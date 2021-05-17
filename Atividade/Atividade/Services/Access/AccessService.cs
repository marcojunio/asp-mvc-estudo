using Atividade.Data;
using Atividade.Models.Access;
using Atividade.ViewModel.Access;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly BuffetDbContext _buffetDbContext;
        private readonly IMapper _mapper;

        public AccessService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            BuffetDbContext buffetDbContext,
            IMapper mapper)
        {
            _mapper = mapper;
            _buffetDbContext = buffetDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AuthenticatedUser(string email,string password)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, password, false, false);
            LastLoginRegister lastLogin = new LastLoginRegister();

            var user = GetUser(email);
            lastLogin.Id = new Guid();
            lastLogin.LastLogin = DateTime.Now;
            lastLogin.User = user;
            
            _buffetDbContext.LastLoginRegisters.Add(lastLogin);
            _buffetDbContext.SaveChanges();


            if (!resultado.Succeeded)
            {
                throw new Exception("Email or password invalid please check your credentials.");
            }
        }


        public User GetUser(string username) 
        {
            var user = _buffetDbContext.Users.Where(x => x.Email == username).Include(x => x.LastLoginRegisters).FirstOrDefault();

            return user;
        }

        public User GetUser(Guid id)
        {
            var user = _buffetDbContext.Users.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public UserViewModel GetUserById(Guid Id)
        {
            var entity = _buffetDbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (entity == null)
                return null;

            return _mapper.Map<UserViewModel>(entity);
        }

        public async Task UpdatePassword(Guid id,string password,string newPassword)
        {
            var user = GetUser(id);
            await _userManager.ChangePasswordAsync(user,password,newPassword);
        }

        public async Task Logout() 
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterUsuario(RegisterUserViewModel model)
        {
            var novoUsuario = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                Cpf = model.Cpf,
                Address = model.Address,
                Age = model.Age,
                Name = model.Name
            };

            var resultado = await _userManager.CreateAsync(novoUsuario,model.Password);

            if (!resultado.Succeeded)
            {
                throw new Exception("Error");
            }
        }
    }
}
