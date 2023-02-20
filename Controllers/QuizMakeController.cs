using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge_Test_CodeFirst.Controllers
{
    public class QuizMakeController : Controller
    {
        private readonly IQuestionRepository questionRepo;
        private readonly IQuizMakeRepository quizMakeRepository;
        private readonly IAnswerRepository passageRepo;
        private readonly IAnswerRepository answerRepo;

        public QuizMakeController(IQuestionRepository questionRepo, IAnswerRepository passageRepo, IAnswerRepository answerRepo, IQuizMakeRepository quizMakeRepository)
        {
            this.questionRepo = questionRepo;
            this.passageRepo = passageRepo;
            this.answerRepo = answerRepo;
            this.quizMakeRepository = quizMakeRepository;
        }
        public IActionResult Index()
        {
            var quizMake = new List<QuizMakeViewModel>();
            var listQuizMake = quizMakeRepository.GetAllQuizMake();
            foreach (var item in listQuizMake)
            {
                var oneQuizMake = new QuizMakeViewModel
                {
                    question = (Question)item.Questions,
                    Quiz = item,
                };
                quizMake.Add(oneQuizMake);
            };

            return View(quizMake);
        }

        public IActionResult Details(int id)
        {
            var oneQuizMake = quizMakeRepository.GetOneQuizMake(id);
            return View(oneQuizMake);
        }
    }
}
