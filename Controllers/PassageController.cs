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
            
            List<QuizPassageViewModel> listViewModel = new List<QuizPassageViewModel>();
            
            foreach (Question questions in fourAnswers)
            {
                var questionViewModel = new QuizPassageViewModel
                {
                    ContentQuestion = questions.ContentQuestion,
                    QuestionId = questions.QuestionId,
                    AnswerChoice= questions.AnswerChoice.ToList(),
                };

                listViewModel.Add(questionViewModel);
            }
            return View(listViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PassageQuiz(QuizPassageViewModel model)
        {


            var resultat = new TheAnswer
            {

            Answers = model.AnswerChoice.Where(x => x.IsCorrect).ToString(),

            };

            return Content($"{resultat.Answers}");

            //answerRepo.CreateResalt(resultat);

            //return RedirectToAction("Index");
        }

    }
}
