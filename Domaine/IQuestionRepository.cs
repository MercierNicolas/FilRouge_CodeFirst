using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuestionRepository
    {
        int CreateQuestion();
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> GetOneQuestion();
        int DeleteQuestion();
    }

    public class DbQuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public DbQuestionRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int CreateQuestion()
        {
            throw new NotImplementedException();
        }

        public int DeleteQuestion()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions;
        }

        public IEnumerable<Question> GetOneQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
