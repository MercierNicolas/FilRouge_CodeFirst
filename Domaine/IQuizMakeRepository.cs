using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuizMakeRepository
    {
        List<Quiz> GetAllQuizMake();
        List<TheAnswer> GetAllAnswersUser();
        QuizMakeViewModel GetOneQuizMake(int id);
        List<TheAnswer> GetAllAnswersUserOfOneQuiz(int id);
    }

    public class DbQuizMakeRepository : IQuizMakeRepository
    {
        private readonly ApplicationDbContext _context;
        public DbQuizMakeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<TheAnswer> GetAllAnswersUser()
        {
            throw new NotImplementedException();
        }

        public List<TheAnswer> GetAllAnswersUserOfOneQuiz(int id)
        {
            throw new NotImplementedException();
        }

        public List<Quiz> GetAllQuizMake()
        {
            var answersList = _context.theAnswers.ToList();
            List<int> idQuizListMake = new List<int>();
            foreach(var answers in answersList)
            {
                idQuizListMake.Add(answers.QuizId);
            }
            var idQuizMakeUnique = idQuizListMake.Distinct().ToList();

            List<Quiz> ListQuizMake = new List<Quiz>();
            foreach(var idUnique in idQuizMakeUnique)
            {
                var item = _context.Quiz.Where(q => q.QuizzId == idUnique).Include(s => s.Sujet).Include(l => l.Level).ToList().First();
                ListQuizMake.Add(item);
            }
           return ListQuizMake;
        }

        public QuizMakeViewModel GetOneQuizMake(int id)
        {
            var quizMake = new QuizMakeViewModel();
            var rep = _context.theAnswers.Where(q => q.QuizId == id);
            var quiz = _context.Quiz.Where(q => q.QuizzId == id).Include(ques => ques.Questions).ThenInclude(a => a.AnswerChoice);
            

            quizMake.answerUser = rep.ToList();
            quizMake.Quiz = quiz.ToList().First();
            return quizMake;
        }
    }
}
