using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class QuizMakeControlleur : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
