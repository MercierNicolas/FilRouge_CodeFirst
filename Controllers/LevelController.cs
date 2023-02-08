using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class LevelController : Controller
    {
        private readonly ILevelRepository levelRepo;

        public LevelController(ILevelRepository levelAdd)
        {
            this.levelRepo = levelAdd;
        }
        public IActionResult Index()
        {
            var listeLevel = levelRepo.GetAllLevel();
            return View(listeLevel);
        }

        public IActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLevel(Level model)
        {
            var levelAjout = new Level()
            {
                LevelName = model.LevelName,
            };
            levelRepo.CreateLevel(levelAjout);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteLevel(int id)
        {
           // var oneLevel = levelRepo.GetOneLevel(id);
            return View();
        }
        [HttpPost]
        public IActionResult DeleteLevel(Level model)
        {
            levelRepo.DeleteLevel(model.Id);
            return RedirectToAction("Index");
        }
    }
    
}
