using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;
        private readonly IAnswerRepository passageRepo;
        private readonly IAnswerRepository answerRepo;
        private readonly IUserRepository userRepo;
        private readonly IQuizRepository quizRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository passageRepo, IAnswerRepository answerRepo, IUserRepository userRepo, IQuizRepository quizRepo)
        {
            this.questionRepo = questionRepo;
            this.passageRepo = passageRepo;
            this.answerRepo = answerRepo;
            this.userRepo = userRepo;
            this.quizRepo = quizRepo;

        }
        [HttpGet]
        [Route("/Passage/Validation/{id:int}")]
        public IActionResult Validation(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);

            return View(dataId.FirstOrDefault());

        }

        [HttpPost]
        [Route("/Passage/Validation/{id:int}")]
        public IActionResult Validation(int id, int? questionId, QuizPassageViewModel model, Quiz quizcode)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);
            var checkcode = quizRepo.GetOneQuiz(id).First();

            var AddCandidat = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.IdentityCandidat.UserName,
                Email = model.IdentityCandidat.Email,
                EmailConfirmed = model.IdentityCandidat.EmailConfirmed,
                PhoneNumber = model.IdentityCandidat.PhoneNumber,
                PhoneNumberConfirmed = model.IdentityCandidat.PhoneNumberConfirmed,
                TwoFactorEnabled = model.IdentityCandidat.TwoFactorEnabled,
                LockoutEnabled = model.IdentityCandidat.LockoutEnabled,
                AccessFailedCount = model.IdentityCandidat.AccessFailedCount,

            };

            if (quizcode.Code == checkcode.Code)
            {
                userRepo.AddCandidat(AddCandidat);
                //return Content(AddCandidat.Email);
                return View("Welcome", dataId.FirstOrDefault());
            }
            else
            {
                return View(dataId.FirstOrDefault());
            }
            //return View(dataId.FirstOrDefault());

            return View("Welcome",dataId.FirstOrDefault());
            return RedirectToAction("{id:int}");

        }
        [HttpGet]
        [Route("/Passage/{id:int}")]
        public IActionResult Welcome(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);
            
            return View(dataId.FirstOrDefault());
        }

        

        [HttpGet]
        [Route("/Passage/{id:int}/{questionId:int}")]
        public IActionResult PassageQuiz(int id, int? questionId)
        {

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);


            return View(dataAnswers);
        }
        [HttpPost]
        [Route("/Passage/{id}/{questionId?}")]
        public IActionResult PassageQuiz(int id, int? questionId, IFormCollection input, QuizPassageViewModel model)
        {

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);

            var responseIds = dataAnswers.AnswerChoice.Where(responseId => input.ContainsKey(responseId.CorrectionId.ToString())).Select(i => i.CorrectionId);
            answerRepo.SaveBddAnswerUser(responseIds, (int)questionId , id);

            if (dataAnswers.NextQuestionId == -1)
            {
                return View("Thank");
            }

            return RedirectToAction("PassageQuiz", new { id, questionId = dataAnswers.NextQuestionId });

        }

        [HttpGet]
        [Route("/Passage/Fake/{id:int}")]
        public IActionResult FakeWelcome(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);

            return View(dataId.FirstOrDefault());
        }
        [HttpGet]
        [Route("/Passage/Fake/{id:int}/{questionId:int}")]
        public IActionResult FakePassageQuiz(int id, int? questionId)
        {

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);


            return View(dataAnswers);
        }
        [HttpPost]
        [Route("/Passage/Fake/{id}/{questionId?}")]
        public IActionResult FakePassageQuiz(int id, int? questionId, IFormCollection input, QuizPassageViewModel model)
        {

            var dataAnswers = passageRepo.GetQuizPassage(id, questionId);

            var responseIds = dataAnswers.AnswerChoice.Where(responseId => input.ContainsKey(responseId.CorrectionId.ToString())).Select(i => i.CorrectionId);
            //answerRepo.SaveBddAnswerUser(responseIds, (int)questionId, id);

            if (dataAnswers.NextQuestionId == -1)
            {
                return View("Thank");
            }

            return RedirectToAction("FakePassageQuiz", new { id, questionId = dataAnswers.NextQuestionId });

        }
        public IActionResult Thank()
        {
            return View();
        }

        public IActionResult ActionResult(int id)
        {
            return View();
        }

    }
}
