using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuizRepository
    {
        int CreateQuiz(Quiz quiz, int levelId, int sujetId ,HttpContext httpContext);
        IEnumerable<Quiz> GetAllQuiz();
        IEnumerable<Quiz> GetOneQuiz(int id);

        int DeleteQuiz(int id);


        int AddQuestionQuiz(int id, List<Question> ListQuestion);
    }

    public class DbQuizRepo : IQuizRepository
    {
        // Permet de vers le lien entre la class DbQuizRepo et le context de l'app (donc la Bdd)
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DbQuizRepo(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this._context = context;
            _userManager = userManager;
        }
        // Methode pour ajoute a la BDD un quiz
        public int CreateQuiz(Quiz quiz, int levelId, int sujetId, HttpContext httpContext)
        {
            // On recupére l'id de la vue a l'aide du controlleur et on appele de la BDD les level avec le where on recupere le bon id
            var selectLvl = _context.levels.Where(lvl => lvl.Id == levelId).First();
            // On ajoute dans la variable quiz l'objet de type Level avec le bon id et le bon nom recupere a la ligne juste en haut
            quiz.Level = (Level?)selectLvl;

            // Meme fonctionnement que en haut mais la pour le Sujet
            var selectSujet = _context.sujets.Where(sujet => sujet.id == sujetId).First();
            quiz.Sujet = (Sujet?)selectSujet;

            // Récupérer l'ID de l'utilisateur
            //string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var name ="";
            foreach (var userName in httpContext.User.Claims)
            {
                name = userName.Subject.Name;                
            }
            var userId = _context.Users.Where(u => u.UserName== name).First();
            quiz.RecruterId = userId;

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

            var QuestionInQuiz = _context.Questions.Where(q => q.Quiz.First().QuizzId== Id).FirstOrDefault();
            if(QuestionInQuiz == null)
            {
                _context.Quiz.RemoveRange(quizADelete);
                _context.SaveChanges();
                return 0;
            }

            return -1;

        }
        public int AddQuestionQuiz(int id, List<Question> ListQuestion)
        {
            var quizSelect = _context.Quiz.Where(q => q.QuizzId == id).First();

            quizSelect.Questions = ListQuestion;
            _context.Quiz.Update(quizSelect);
            _context.SaveChanges();

            return 0;
        }



    }
}
