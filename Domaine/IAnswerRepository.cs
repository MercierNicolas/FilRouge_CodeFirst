using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IAnswerRepository
    {
        int CreateResalt(TheAnswer theAnswer);
    }

    public class DbTheAnswerRepo : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public DbTheAnswerRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int CreateResalt(TheAnswer theAnswer)
        {

            _context.theAnswers.Add(theAnswer);
            _context.SaveChanges();
            return theAnswer.TheAnswerId;
        }


    }
}
