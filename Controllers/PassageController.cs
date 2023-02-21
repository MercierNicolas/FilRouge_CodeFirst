using FilRouge_Test_CodeFirst.Domaine;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilRouge_Test_CodeFirst.Controllers
{
    public class PassageController : Controller
    {
        private readonly IQuestionRepository questionRepo;
        private readonly IAnswerRepository passageRepo;
        private readonly IAnswerRepository answerRepo;

        public PassageController(IQuestionRepository questionRepo, IAnswerRepository passageRepo, IAnswerRepository answerRepo)
        {
            this.questionRepo = questionRepo;
            this.passageRepo = passageRepo;
            this.answerRepo = answerRepo;
            
        }

        public IActionResult Index()
        {
            
            return View();
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
            //Save en bdd
  
            if (dataAnswers.NextQuestionId == -1)
            {


                //=======
                //            if (questionId == null)
                //>>>>>>> 4aba78afc29b16f7ddf829dd17a76b6b01f85a60
                {
                    return View("Thank");
                }
            }
            return RedirectToAction("PassageQuiz", new { id, questionId = dataAnswers.QuestionId });
        }



    }
}
