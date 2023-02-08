using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface ISujetRepository
    {
        int CreateSujet(Sujet sujet);
        IEnumerable<Sujet> GetAllSujet();
        IEnumerable<Sujet> GetOneSujet(int id);
        int DeleteSujet(int id);
    }

    public class DbSujetlRepo : ISujetRepository
    {
        private readonly ApplicationDbContext _context;
        public DbSujetlRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int CreateSujet(Sujet sujet)
        {
            _context.sujets.Add(sujet);
            _context.SaveChanges();
            return sujet.id;
        }
        public IEnumerable<Sujet> GetAllSujet()
        {
            return _context.sujets;
        }

        public IEnumerable<Sujet> GetOneSujet(int id)
        {
            return _context.sujets.Where(l => l.id == id).ToList();
        }

        public int DeleteSujet(int id)
        {
            var SujetlAdelete = _context.sujets.Where(l => l.id == id).ToList();
            _context.sujets.RemoveRange(SujetlAdelete);
            _context.SaveChanges();
            return 0;
        }

    }
}
