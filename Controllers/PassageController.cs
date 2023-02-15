using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;

        public PassageController(IQuestionRepository questionRepo)
        {
            this.questionRepo = questionRepo;
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
    }
}
