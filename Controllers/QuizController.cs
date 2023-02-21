using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilRouge_Test_CodeFirst.Controllers
{
	public class QuizController : Controller
	{
        
        private readonly IQuizRepository quizRepo;
        private readonly ILevelRepository levelRepo;
        private readonly ISujetRepository sujetRepo;

        private readonly IQuestionRepository questionRepo;
        private readonly IHashids _hashids;

        // Permet d'apeller les Interface ou ce trouve les methodes qui permet le CRUD
        public QuizController(IQuizRepository quizAdd, ILevelRepository levelRepo, ISujetRepository sujetRepo, IHashids hashids, IQuestionRepository questionRepo)

        {
            // Permet d'affecter à la variable l'interface afin de pouvoir utiliser les méthode
            this.quizRepo = quizAdd;
            this.levelRepo = levelRepo;
            this.sujetRepo = sujetRepo;
            this.questionRepo = questionRepo;

            _hashids = hashids;

        }
        public IActionResult Index()
		{
            var listeQuiz = quizRepo.GetAllQuiz();
            
            return View(listeQuiz);
        }

        // création du hashid
        [HttpGet("hashids/{id}")]
        public IActionResult GetCode([FromRoute] string id)
        {
            var rawId = _hashids.Decode(id);
            if(rawId.Length == 0)
            {
                return NotFound();
            }
            return Ok(rawId);
        }


		public IActionResult AddQuiz()
		{
            // On crée un QuizViewModel qui comprend les contenue d'un quiz
            QuizViewModel QuizViewModel = new QuizViewModel();
            QuizViewModel.Quiz = new Quiz();
            // Recuper tout les sujet et level 
            var allLvl = levelRepo.GetAllLevel();
            var allSujet = sujetRepo.GetAllSujet();

            List<SelectListItem> Listlevel = allLvl
                .OrderBy(n => n.LevelName)
                .Select(n =>
                    new SelectListItem
                    {
                        // Permet de crée une liste d'item afin de les afficher dans la vue dans un select
                        Text = n.LevelName,
                        Value = n.Id.ToString()
                    })
                .ToList();

            List<SelectListItem> ListSujet = allSujet.OrderBy(n => n.SujetName)
                .Select(n =>
                    new SelectListItem
                    {
                        // Permet de crée une liste d'item afin de les afficher dans la vue dans un select
                        Text = n.SujetName,
                        Value = n.id.ToString()
                    }).ToList();



            // On ajoute au model QuizVieuxModel les liste des level et sujet
            QuizViewModel.AllLevel = Listlevel;
            QuizViewModel.AllSujet = ListSujet;
            return View(QuizViewModel);
        }

        [HttpPost]
        public IActionResult AddQuiz(QuizViewModel model)
        {
           
            // On crée une variable de type quiz que stock le nom le code et l'Averrage
            var quizAdd = new Quiz()
            {
                Name = model.Quiz.Name,
                Average = model.Quiz.Average,
                Code = generateGuid(),
            };
            // On envoie la variable quizAdd et le level et sujet ID recupére dans le select a la méthode CreateQuiz de l'interface
            quizRepo.CreateQuiz(quizAdd , model.LevelId , model.sujetId);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteQuiz(int id)
        {
            var OneQuiz = quizRepo.GetOneQuiz(id);
            
            return View(OneQuiz.First());
        }
        [HttpPost]
        public IActionResult DeleteQuiz(Quiz model)
        {
            quizRepo.DeleteQuiz(model.QuizzId);
            return RedirectToAction("Index");
        }
        public string generateGuid()
        {
            // création du guid
            var guid = Guid.NewGuid().ToString();
            return guid;
        }


        public IActionResult EditQuiz(int id)
        {
            var editQuiz = quizRepo.GetOneQuiz(id);
            
            return View(editQuiz.First()); 
        }

        public IActionResult DetailQuiz (int id)
        {
            var DetailQuiz = quizRepo.GetOneQuiz(id);

            return View(DetailQuiz.First());
        }

        public IActionResult AddQuestionQuiz(int id)
        {
            var OneQuiz = quizRepo.GetOneQuiz(id).ToList().First();
            var questionList = questionRepo.GetQuestionWithSujet(OneQuiz.Sujet);
            var addQuestionQuiz = new AddQuestionQuizViewModel
            {
                QuizAddQuestion = (Quiz)OneQuiz,
                QuestionList = questionList,

            };
            return View(addQuestionQuiz);
        }

        [HttpPost]
        public IActionResult AddQuestionQuiz(AddQuestionQuizViewModel model)
        {
            var listQuestion = model.IsCheckedQuestionID;
            var idQuiz = model.QuizAddQuestion.QuizzId;

            var questionList = questionRepo.GetQuestionWithIds(listQuestion);




            quizRepo.AddQuestionQuiz(idQuiz, questionList);
            return RedirectToAction("Index");
        }

    }
}
