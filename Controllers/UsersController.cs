using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepo;


        public UsersController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public ActionResult CreateUser()
        {

            return View("CreateUser");
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel identity)
        {

            var AddUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = identity.UserName,
                PasswordHash =  identity.PasswordHash/*Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8))*/,
                Email = identity.Email,
                EmailConfirmed = identity.EmailConfirmed,
                PhoneNumber = identity.PhoneNumber,
                PhoneNumberConfirmed = identity.PhoneNumberConfirmed,
                TwoFactorEnabled = identity.TwoFactorEnabled,
                LockoutEnabled = identity.LockoutEnabled,
                AccessFailedCount = identity.AccessFailedCount,

            };
            userRepo.AddUser(AddUser);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteUser(string Id)
        {
            var cancellOneUser = userRepo.GetOneUser(Id);
            var s = new UserViewModel
            {
                IdentityUser = cancellOneUser.ToList(),
            };
            return View(s);
        }

        [HttpPost]
        public ActionResult DeleteUser(IdentityUser user)
        {
            userRepo.DeleteUser(user.Id);
            return RedirectToAction("Index");
        }


        public ActionResult DetailUser(string Id)
        {
            var detailOneUser = userRepo.GetOneUser(Id);
            var d = new UserViewModel
            {
                IdentityUser = detailOneUser.ToList(),
            };
            foreach (var u in detailOneUser)
            {
                d.UserName= u.UserName;
                d.Email= u.Email;
                d.PhoneNumber= u.PhoneNumber;
            };

            return View(d);
        }

        public ActionResult EditUser(string Id)
        {
            var modifyOneUser = userRepo.GetOneUser(Id);
            var e = new UserViewModel
            {
                IdentityUser = modifyOneUser.ToList(),
            };
            return View(e);
        }
        [HttpPost]
        public ActionResult EditUser(string id, IdentityUser user)
        {

            userRepo.Edit(user.Id , user);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var listUser = userRepo.GetAllUser();
            var u = new UserViewModel
            {
                IdentityUser = listUser.ToList(),
            };
            return View(u);
        }
    }
}
