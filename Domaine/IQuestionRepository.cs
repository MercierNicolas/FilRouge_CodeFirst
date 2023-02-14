using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuestionRepository
    {
        int CreateQuestion(Question question, int levelId, int sujetId);
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

        public int CreateQuestion(Question question, int levelId, int sujetId)
        {
            // On recupére l'id de la vue a l'aide du controlleur et on appele de la BDD les level avec le where on recupere le bon id
            var selectLvl = _context.levels.Where(lvl => lvl.Id == levelId).First();
            // On ajoute dans la variable quiz l'objet de type Level avec le bon id et le bon nom recupere a la ligne juste en haut
            question.Level = (Level?)selectLvl;

            // Meme fonctionnement que en haut mais la pour le Sujet
            var selectSujet = _context.sujets.Where(sujet => sujet.id == sujetId).First();
            question.Sujet = (Sujet?)selectSujet;

            _context.Questions.Add(question);
            _context.SaveChanges();
            return question.QuestionId;
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
