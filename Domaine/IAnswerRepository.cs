using Azure.Core;
using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;


namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IAnswerRepository
    {
        int CreateResalt(TheAnswer theAnswer);
        QuizPassageViewModel GetQuizPassage(int quizzId, int? questionId);
        List<QuizPassageViewModel> GetAllId(int quizzId, int? questionIdControlleur);

        int SaveBddAnswerUser (IEnumerable<int> IdCheck ,int questionIdControlleur, int quizId);

    }

    public class DbTheAnswerRepo : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public DbTheAnswerRepo(ApplicationDbContext context)
        {
            this._context = context;
        }


        public List<QuizPassageViewModel> GetAllId(int quizzId, int? questionId)
        {
            var getId = _context.Quiz.Include(q => q.Questions);

            List<QuizPassageViewModel> listId = new List<QuizPassageViewModel>();

            foreach (Quiz q in getId)
            {
                foreach (Question qtion in q.Questions)
                {
                    var id = new QuizPassageViewModel
                    {
                        QuizzId = q.QuizzId,
                        QuestionId = qtion.QuestionId,
                    };
                    listId.Add(id);
                }
            }

            return listId;
        }



        public QuizPassageViewModel GetQuizPassage(int quizzId, int? questionIdControlleur)

        {
            var PassageQuizViewModel = new QuizPassageViewModel();

            var quizPassage = _context.Quiz
               .Include(qs => qs.Questions)
               .ThenInclude(a => a.AnswerChoice)
               .Include(l => l.Level)
               .Include(s => s.Sujet)
               .FirstOrDefault(fq => fq.QuizzId == quizzId);
               
            List<int> listQuestionId = new List<int>();
            foreach(var question in quizPassage.Questions)
            {
                listQuestionId.Add(question.QuestionId);

            }

            listQuestionId.Add(-1);
            if (listQuestionId.Contains((int)questionIdControlleur))
            {
                var oneQuiestion = quizPassage.Questions.Where(q => q.QuestionId == questionIdControlleur);
                PassageQuizViewModel.QuizzId = quizzId;
                PassageQuizViewModel.QuestionId = oneQuiestion.FirstOrDefault().QuestionId;
                PassageQuizViewModel.ContentQuestion = oneQuiestion.FirstOrDefault().ContentQuestion;
                PassageQuizViewModel.AnswerChoice = oneQuiestion.First().AnswerChoice.ToList();
                var indexID = listQuestionId.IndexOf((int)questionIdControlleur);


               PassageQuizViewModel.NextQuestionId = listQuestionId[indexID + 1];
                
                return PassageQuizViewModel;
            }
            return PassageQuizViewModel;
        }

        public int CreateResalt(TheAnswer theAnswer)
        {

            _context.theAnswers.Add(theAnswer);
            _context.SaveChanges();
            return theAnswer.TheAnswerId;
        }

        public int SaveBddAnswerUser(IEnumerable<int> IdCheck, int questionIdControlleur, int quizId)
        {

            var questionSelect = _context.Questions.Where(qId => qId.QuestionId == questionIdControlleur).Include(r => r.AnswerChoice).FirstOrDefault();  
            foreach(var idCheck in IdCheck)
            {
                var saveAnswer = new TheAnswer { QuestionsId = questionSelect, choiceIdUser = idCheck , QuizId = quizId };
                foreach(var repAttendu in questionSelect.AnswerChoice)
                {
                    if(repAttendu.CorrectionId == idCheck && repAttendu.IsCorrect)

                    {
                        saveAnswer.IsBonnrep = true;
                    }
                }

                _context.theAnswers.Add(saveAnswer);   

            }
            _context.SaveChanges();
            return 0;
        }
    }
}
