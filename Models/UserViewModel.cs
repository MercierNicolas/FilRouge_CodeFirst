using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string ?UserName { get; set; }
        [DataType(DataType.Password)]
        public string ?PasswordHash { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ?Email { get; set; }
        [Compare("Email", ErrorMessage = "Votre email n'est pas bon")]
        public bool EmailConfirmed { get; set; } = true;
        public string ?PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int QuizzId { get; set; }
        public List<IdentityUser> IdentityUser { get; set; }
        public List<Quiz> ?Quizs { get; set; }
        public Quiz Quiz { get; set; }
    }


}
