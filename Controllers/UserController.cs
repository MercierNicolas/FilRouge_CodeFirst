using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepo;


        public UserController(IUserRepository userRepo)
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
                Id = identity.Id,
                UserName = identity.UserName,
                PasswordHash = identity.PasswordHash,
                Email = identity.Email,
                EmailConfirmed = identity.EmailConfirmed,
                PhoneNumber = identity.PhoneNumber,
                PhoneNumberConfirmed = identity.PhoneNumberConfirmed,
                TwoFactorEnabled = identity.TwoFactorEnabled,
                LockoutEnabled = identity.LockoutEnabled,
                AccessFailedCount = identity.AccessFailedCount,

            };
            userRepo.CreateUser(AddUser);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteUser(string Id)
        {
            var cancellOneUser = userRepo.GetOneUser(Id);
            return View(cancellOneUser.First());
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
            return View(detailOneUser.First());
        }

        public ActionResult EditUser(string Id)
        {
            var modifyOneUser = userRepo.GetOneUser(Id);
            return View(modifyOneUser.First());
        }
        [HttpPost]
        public ActionResult EditUser(string id, IdentityUser user)
        {
            userRepo.Edit(user.Id , user);
            return RedirectToAction("Manage");
        }

        public IActionResult Index()
        {
            var listUser = userRepo.GetAllUser();
            return View(listUser);
        }
    }
}
