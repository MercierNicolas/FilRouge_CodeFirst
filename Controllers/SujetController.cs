using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class SujetController : Controller
    {
        private readonly ISujetRepository sujetRepo;

        public SujetController(ISujetRepository sujetAdd)
        {
            this.sujetRepo = sujetAdd;
        }
        public IActionResult Index()
        {
            var listeSujet= sujetRepo.GetAllSujet();
            return View(listeSujet);
        }

        public IActionResult AddSujet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSujet(Sujet model)
        {
            var sujetAjout = new Sujet()
            {
                SujetName = model.SujetName,
            };
            sujetRepo.CreateSujet(sujetAjout);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSujet(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteLevel(Level model)
        {
            sujetRepo.DeleteSujet(model.Id);
            return RedirectToAction("Index");
        }
    }
}
