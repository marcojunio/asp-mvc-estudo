using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.ViewModel.Access
{
    public class RegisterUserViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-mail is required.")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password),ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "Confirm password is required.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Cpf is required.")]
        public string Cpf { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
