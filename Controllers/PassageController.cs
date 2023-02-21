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



        public IActionResult Validation(int id, int? questionId)
        {
            var dataId = passageRepo.GetAllId(id, questionId).Where(q => q.QuizzId == id);

            return View(dataId.FirstOrDefault());
          
        }

        [HttpPost]
        public IActionResult Validation(int id, int? questionId, UserViewModel identity, Quiz quizcode)
        {
            
            var checkcode = quizRepo.GetOneQuiz(id).First();

            var AddCandidat = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = identity.UserName,

                Email = identity.Email,
                EmailConfirmed = identity.EmailConfirmed,
                PhoneNumber = identity.PhoneNumber,
                PhoneNumberConfirmed = identity.PhoneNumberConfirmed,
                TwoFactorEnabled = identity.TwoFactorEnabled,
                LockoutEnabled = identity.LockoutEnabled,
                AccessFailedCount = identity.AccessFailedCount,

            };

            if (quizcode.Code == checkcode.Code)
            {
                userRepo.AddUser(AddCandidat);
                
            }
            return Content("je suis ici");
            return View("Welcome");

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

            answerRepo.SaveBddAnswerUser(responseIds, (int)questionId, id);

            if (dataAnswers.NextQuestionId == -1)
            {
                return View("Thank");
            }

            return RedirectToAction("PassageQuiz", new { id, questionId = dataAnswers.NextQuestionId });
        }


        //public IActionResult Thank()
        //{
        //    return View();
        //}


    }
}
