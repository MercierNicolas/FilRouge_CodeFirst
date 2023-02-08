using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuizRepository
    {
        int CreateQuiz(Quiz quiz, int levelId);
        IEnumerable<Quiz> GetAllQuiz();
    }

    public class DbQuizRepo : IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public DbQuizRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int CreateQuiz(Quiz quiz, int levelId)
        {
            var selectLvl = _context.levels.Where(lvl => lvl.Id == levelId).First();
            quiz.Level = (Level?)selectLvl;
            _context.Quiz.Add(quiz);
            _context.SaveChanges();
            return quiz.QuizzId;
        }

        public IEnumerable<Quiz> GetAllQuiz()
        {
            return _context.Quiz.Include(l => l.Level).ToList();
        }
    }
}
