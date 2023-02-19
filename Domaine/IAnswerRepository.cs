using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using FilRouge_Test_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;


namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IAnswerRepository
    {
        int CreateResalt(TheAnswer theAnswer);
        QuizPassageViewModel GetQuizPassage(int quizzId, int? questionId);
        List<QuizPassageViewModel> GetAllId(int quizzId, int? questionId);

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

        public QuizPassageViewModel GetQuizPassage(int quizzId, int? questionId)
        {

            var quizPassage = _context.Quiz
                .Include(qs => qs.Questions)
                .ThenInclude(a => a.AnswerChoice)
                .Include(l => l.Level)
                .Include(s => s.Sujet)
                .ToList()
                .FirstOrDefault(fq => fq.QuizzId == quizzId);




            var questionViewModel = new QuizPassageViewModel();

            var nbQuestion = quizPassage.Questions.Count();

            int current = 0;


            foreach (var dataAnswer in quizPassage.Questions)
            {
                questionViewModel.QuizzId = quizzId;
                questionViewModel.QuestionId = dataAnswer.QuestionId;
                questionViewModel.ContentQuestion = dataAnswer.ContentQuestion;
                questionViewModel.AnswerChoice = dataAnswer.AnswerChoice.ToList();

                if (current != 0)
                {
                    questionViewModel.QuizzId = quizzId;
                    questionViewModel.QuestionId = dataAnswer.QuestionId;
                    questionViewModel.ContentQuestion = dataAnswer.ContentQuestion;
                    questionViewModel.AnswerChoice = dataAnswer.AnswerChoice.ToList();
                    questionViewModel.NextQuestionId = current;
                }
                current++;

            }


            return questionViewModel;
        }


        public int CreateResalt(TheAnswer theAnswer)
        {

            _context.theAnswers.Add(theAnswer);
            _context.SaveChanges();
            return theAnswer.TheAnswerId;
        }


    }
}
