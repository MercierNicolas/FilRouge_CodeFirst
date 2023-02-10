using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilRouge_Test_CodeFirst.Controllers
{
	public class QuizController : Controller
	{
        
        private readonly IQuizRepository quizRepo;
        private readonly ILevelRepository levelRepo;
        private readonly ISujetRepository sujetRepo;

        public QuizController(IQuizRepository quizAdd, ILevelRepository levelRepo, ISujetRepository sujetRepo)
        {
            this.quizRepo = quizAdd;
            this.levelRepo = levelRepo;
            this.sujetRepo = sujetRepo;

        }
        public IActionResult Index()
		{
            var listeQuiz = quizRepo.GetAllQuiz();
            
            return View(listeQuiz);
        }

		public IActionResult AddQuiz()
		{
            
            QuizViewModel QuizViewModel = new QuizViewModel();
            QuizViewModel.Quiz = new Quiz();

            var allLvl = levelRepo.GetAllLevel();
            var allSujet = sujetRepo.GetAllSujet();

            List<SelectListItem> Listlevel = allLvl.OrderBy(n => n.LevelName)
                .Select(n =>
                    new SelectListItem
                    {
                        Text = n.LevelName,
                        Value = n.Id.ToString()
                    }).ToList();

            List<SelectListItem> ListSujet = allSujet.OrderBy(n => n.SujetName)
                .Select(n =>
                    new SelectListItem
                    {
                        Text = n.SujetName,
                        Value = n.id.ToString()
                    }).ToList();




            QuizViewModel.AllLevel = Listlevel;
            QuizViewModel.AllSujet = ListSujet;
            return View(QuizViewModel);
        }

        [HttpPost]
        public IActionResult AddQuiz(QuizViewModel model,Level lvl)
        {
            var quizAdd = new Quiz()
            {
                Name = model.Quiz.Name,
                Average = model.Quiz.Average,
                Code = model.Quiz.Code,
               
            };

            quizRepo.CreateQuiz(quizAdd , model.LevelId , model.sujetId);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteQuiz(int id)
        {
            var OneQuiz = quizRepo.GetOneQuiz(id);
            
            return View(OneQuiz.First());
        }

    }
}
