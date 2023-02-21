using Azure.Core;
using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IUserRepository
    {
        string AddUser(IdentityUser user);
        string AddCandidat(IdentityUser user, int idQuiz);
        string DeleteUser(string IdUser);
        IEnumerable<IdentityUser> GetAllUser();
        string Edit(string id, IdentityUser user);
        IEnumerable<IdentityUser> GetOneUser(string IdUser);
    }
    
    public class DbUserRepo : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public DbUserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public string AddCandidat(IdentityUser user, int idQuiz)
        {

            var role = _context.Roles.Where(r => r.Name == "Candidats").First();

            var newUserRole = new IdentityUserRole<String>
            {
                UserId = user.Id,
                RoleId = role.Id,
            };

            _context.UserRoles.Add(newUserRole);
            _context.Users.Add(user);
            _context.SaveChanges();
            var tested = new Tested
            {
                QuizzId = idQuiz,
                IdentityUserId = user.Id,
                TestedDate = DateTime.Now,
            };
            _context.tests.Add(tested);
            _context.SaveChanges();
            return user.Id;
        }

        public string AddUser(IdentityUser user)
        {
            var pw = user.UserName + "QUIZ_2023!";
            var hash = new PasswordHasher<IdentityUser>();
            var passwordHash = hash.HashPassword(user, pw);
            user.PasswordHash = passwordHash;
            user.NormalizedUserName = user.Email.ToLower();
            var role = _context.Roles.Where(r => r.Name == "Recruiter").First();

            var newUserRole = new IdentityUserRole<String>
            {
                UserId = user.Id,
                RoleId = role.Id,
            };

            _context.UserRoles.Add(newUserRole);
            _context.Users.Add(user);
            _context.SaveChanges();
            
            return user.Id;

        }

        public string DeleteUser(string IdUser)
        {
            var userDelete = _context.Users.Where(u => u.Id == IdUser).ToList();
            _context.RemoveRange(userDelete);
            _context.SaveChanges();
            return "";
        }

        public IEnumerable<IdentityUser> GetAllUser()
        {
            return _context.Users.ToList();
        }


        public IEnumerable<IdentityUser> GetOneUser(string IdUser)
        {
            return _context.Users.Where(o => o.Id == IdUser).ToList();
        }

        public string Edit(string id, IdentityUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return "";

        }

    }
}
