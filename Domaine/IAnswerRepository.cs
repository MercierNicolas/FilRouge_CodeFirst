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
    }

    public class DbTheAnswerRepo : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public DbTheAnswerRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public QuizPassageViewModel GetQuizPassage(int quizzId, int? questionId)
        {
            var quizPassage = _context.Quiz
                .Include(qs => qs.Questions)
                .ThenInclude(a => a.AnswerChoice)
                .Include(l => l.Level)
                .Include(s => s.Sujet)
                .FirstOrDefault(fq => fq.QuizzId == quizzId);

            var questionViewModel = new QuizPassageViewModel();

            foreach (var dataAnswer in quizPassage.Questions)
            {
                questionViewModel.QuizzId = quizzId;
                questionViewModel.QuestionId = dataAnswer.QuestionId;
                questionViewModel.ContentQuestion = dataAnswer.ContentQuestion;
                questionViewModel.AnswerChoice = dataAnswer.AnswerChoice.ToList();

                return questionViewModel;
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
