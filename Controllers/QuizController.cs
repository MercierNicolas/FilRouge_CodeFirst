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


        public QuizController(IQuizRepository quizAdd, ILevelRepository levelRepo)
        {
            this.quizRepo = quizAdd;
            this.levelRepo = levelRepo;
            
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

            var test = levelRepo.GetAllLevel();

            List<SelectListItem> level = test.OrderBy(n => n.LevelName)
                .Select(n =>
                    new SelectListItem
                    {
                        Text = n.LevelName,
                        Value = n.Id.ToString()
                    }).ToList();
            QuizViewModel.AllLevel = level;
            return View(QuizViewModel);
        }

        [HttpPost]
        public IActionResult AddQuiz(QuizViewModel model,Level lvl)
        {
            model.Quiz = new Quiz()
            {
                Name = model.Quiz.Name,
                Average = model.Quiz.Average,
                
                Code = model.Quiz.Code,
                Level = model.Quiz.Level,
            };
            var quizAdd = new Quiz()
            {
                Name = model.Quiz.Name,
                Average = model.Quiz.Average,
                Code = model.Quiz.Code,
               
            };

            quizRepo.CreateQuiz(quizAdd , model.LevelId);

            return RedirectToAction("Index");
        }

    }
}
