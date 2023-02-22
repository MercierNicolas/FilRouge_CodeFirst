using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface ILevelRepository
    {
        int CreateLevel(Level level);
        IEnumerable<Level> GetAllLevel();
        IEnumerable<Level> GetOneLevel(int id);
        int DeleteLevel(int id);
    }

    public class DbLevelRepo : ILevelRepository
    {
        private readonly ApplicationDbContext _context;
        public DbLevelRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public int CreateLevel(Level level)
        {
            _context.levels.Add(level);
            _context.SaveChanges();
            return level.Id;
        }
        public IEnumerable<Level> GetAllLevel()
        {
            return _context.levels;
        }

        public IEnumerable<Level> GetOneLevel(int id)
        {
            return _context.levels.Where(l => l.Id == id).ToList();
        }
        
        public int DeleteLevel(int id)
        {
            var isInQuiz = _context.Quiz.Where(q => q.Level.Id == id).FirstOrDefault();
            var isInQuestion = _context.Questions.Where(q => q.Level.Id== id).FirstOrDefault();
            if(isInQuestion == null || isInQuiz == null)
            {
                var levelAdelete = _context.levels.Where(l => l.Id == id).ToList();
                _context.levels.RemoveRange(levelAdelete);
                _context.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
            }

            
        }

    }
}
