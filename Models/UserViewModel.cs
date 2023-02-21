using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace FilRouge_Test_CodeFirst.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string ?UserName { get; set; }
        public string ?PasswordHash { get; set; }
        public string ?Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ?PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int QuizzId { get; set; }
        public List<IdentityUser> IdentityUser { get; set; }
        public List<Quiz> ?Quiz { get; set; }
    }


}
