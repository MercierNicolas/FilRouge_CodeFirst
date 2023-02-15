using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;
        private readonly IAnswerRepository answerRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            this.questionRepo = questionRepo;
            this.answerRepo = answerRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassageQuiz()
        {
            var fourAnswers = questionRepo.GetAllQuestions();


            return View(fourAnswers);
        }

        [HttpPost]
        public IActionResult PassageQuiz(Question model)
        {
            var resultat = new QuizPassageViewModel
            {
                ContentQuestion = model.ContentQuestion,
                AnswerChoice= model.AnswerChoice,
                
            };

            answerRepo.CreateResalt(resultat);

            return RedirectToAction("Index");
        }

    }
}
