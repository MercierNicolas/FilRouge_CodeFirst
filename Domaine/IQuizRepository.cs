using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuizRepository
    {
        int CreateQuiz(Quiz quiz, int levelId, int sujetId);
        IEnumerable<Quiz> GetAllQuiz();
        IEnumerable<Quiz> GetOneQuiz(int id);
    }

    public class DbQuizRepo : IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public DbQuizRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int CreateQuiz(Quiz quiz, int levelId, int sujetId)
        {
            var selectLvl = _context.levels.Where(lvl => lvl.Id == levelId).First();
            quiz.Level = (Level?)selectLvl;

            var selectSujet = _context.sujets.Where(sujet => sujet.id == sujetId).First();
            quiz.Sujet = (Sujet?)selectSujet;


            _context.Quiz.Add(quiz);
            _context.SaveChanges();
            return quiz.QuizzId;
        }

        public IEnumerable<Quiz> GetAllQuiz()
        {
            return _context.Quiz.Include(l => l.Level).Include(s => s.Sujet).ToList();
        }

        public IEnumerable<Quiz> GetOneQuiz(int Id)
        {
            yield return _context.Quiz.Where(q => q.QuizzId == Id).First();
        }
    }
}
