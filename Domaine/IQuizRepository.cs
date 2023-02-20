using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuizRepository
    {
        int CreateQuiz(Quiz quiz, int levelId, int sujetId);
        IEnumerable<Quiz> GetAllQuiz();
        IEnumerable<Quiz> GetOneQuiz(int id);

        int DeleteQuiz(int id);
<<<<<<< HEAD
        int AddQuestionQuiz(int id, List<Question> ListQuestion);
=======

        int AddQuestionQuiz(int id, List<Question> ListQuestion);

>>>>>>> ae4399c48f0650e2ba0511a41cff6dc61c50adaa
    }

    public class DbQuizRepo : IQuizRepository
    {
        // Permet de vers le lien entre la class DbQuizRepo et le context de l'app (donc la Bdd)
        private readonly ApplicationDbContext _context;
        public DbQuizRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        // Methode pour ajoute a la BDD un quiz
        public int CreateQuiz(Quiz quiz, int levelId, int sujetId)
        {
            // On recupére l'id de la vue a l'aide du controlleur et on appele de la BDD les level avec le where on recupere le bon id
            var selectLvl = _context.levels.Where(lvl => lvl.Id == levelId).First();
            // On ajoute dans la variable quiz l'objet de type Level avec le bon id et le bon nom recupere a la ligne juste en haut
            quiz.Level = (Level?)selectLvl;

            // Meme fonctionnement que en haut mais la pour le Sujet
            var selectSujet = _context.sujets.Where(sujet => sujet.id == sujetId).First();
            quiz.Sujet = (Sujet?)selectSujet;

            // On ajoute le quiz crée dans le context et on sauvegarde
            _context.Quiz.Add(quiz);
            _context.SaveChanges();
            return quiz.QuizzId;
        }

        public IEnumerable<Quiz> GetAllQuiz()
        {
            return _context.Quiz.Include(l => l.Level).Include(s => s.Sujet).Include(q => q.Questions).ToList();
        }

        public IEnumerable<Quiz> GetOneQuiz(int Id)
        {
            return _context.Quiz.Where(q => q.QuizzId == Id).Include(l => l.Level).Include(s => s.Sujet).Include(q => q.Questions).ToList();
        }


        public int DeleteQuiz(int Id)
        {
            var quizADelete = _context.Quiz.Where(q => q.QuizzId == Id).ToList();
            _context.Quiz.RemoveRange(quizADelete);
            _context.SaveChanges();
            return 0;

        }
        public int AddQuestionQuiz(int id, List<Question> ListQuestion)
        {
            var quizSelect = _context.Quiz.Where(q => q.QuizzId == id).First();

            // var i = 0;
            //// List<Question> ListQuestionSelect;
            // foreach (var questionIdSelect in ListIdQuestion)
            // {
            //    var ListQuestionSelect = _context.Questions.Where(q => q.QuestionId == questionIdSelect).ToList();

            //     quizSelect.Questions = (ICollection<Question>?)ListQuestionSelect;



            // }
            quizSelect.Questions = ListQuestion;
            _context.Quiz.Update(quizSelect);
            _context.SaveChanges();

            return 0;
        }

        public int AddQuestionQuiz(int id, List<Question> ListQuestion)
        {
            var quizSelect = _context.Quiz.Where(q => q.QuizzId == id).First();

            // var i = 0;
            //// List<Question> ListQuestionSelect;
            // foreach (var questionIdSelect in ListIdQuestion)
            // {
            //    var ListQuestionSelect = _context.Questions.Where(q => q.QuestionId == questionIdSelect).ToList();

            //     quizSelect.Questions = (ICollection<Question>?)ListQuestionSelect;



            // }
            quizSelect.Questions = ListQuestion;
            _context.Quiz.Update(quizSelect);
            _context.SaveChanges();

            return 0;
        }





    }
}
