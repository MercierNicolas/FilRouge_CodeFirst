using FilRouge_Test_CodeFirst.Data;
using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

using FilRouge_Test_CodeFirst.Models;


namespace FilRouge_Test_CodeFirst.Domaine
{
    public interface IQuestionRepository
    {

        int CreateQuestion(Question question, int levelId, int sujetId, Dictionary<string, bool> DictionaryChoix);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> GetOneQuestion(int id);
        int DeleteQuestion(int id);

        int UpdateQuestion(int id, Question question /*, Dictionary<string, bool> DictionaryChoix*/);
        List<Question> GetQuestionWithSujet(Sujet sujet);
        List<Question> GetQuestionWithIds(List<int> ids);

    }

    public class DbQuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public DbQuestionRepository(ApplicationDbContext context)
        {
            this._context = context;
        }




        public int CreateQuestion(Question question, int levelId, int sujetId ,Dictionary<string,bool> DictionaryChoix)

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
            var lastIdQuestion = _context.Questions.OrderBy(i => i.QuestionId).Last();


            foreach (var item in DictionaryChoix)
            {
                var saveChoice = new AnswerChoice { ContentCorection = item.Key, IsCorrect = item.Value, questionId = lastIdQuestion };
                _context.AnswerChoice.Add(saveChoice);
                //  saveChoice.questionId = lastIdQuestion.QuestionId;
                //_context.AnswerChoice.Add(saveChoice);
                _context.SaveChanges();
            }

            return question.QuestionId;
        }

        public int DeleteQuestion(int id)

        {
            throw new NotImplementedException();
        }


        public IEnumerable<Question> GetAllQuestions()
        {

            return _context.Questions.Include(l => l.Level).Include(s => s.Sujet).Include(rep => rep.AnswerChoice).ToList();
        }

        public IEnumerable<Question> GetOneQuestion(int id)
        {
            return _context.Questions.Where(q => q.QuestionId == id).Include(rep => rep.AnswerChoice).ToList();
        }
        public int UpdateQuestion(int id, Question question/*, Dictionary<string, bool> DictionaryChoix*/)
        {
            _context.Questions.Update(question);
            //foreach(var rep in DictionaryChoix)
            //{
            //    var saveChoice = new AnswerChoice { ContentCorection = rep.Key, IsCorrect = rep.Value, questionId = question };
            //    _context.AnswerChoice.Update(saveChoice);
            //}

            _context.SaveChanges();
            return 0;
        }

        public List<Question> GetQuestionWithSujet(Sujet sujet)
        {
            return _context.Questions.Where(q => q.Sujet == sujet).Include(rep => rep.AnswerChoice).Include(s => s.Sujet).ToList();
        }


        public List<Question> GetQuestionWithIds(List<int> ids)


        {

            var allQuestion = GetAllQuestions();
            List<Question> result = new List<Question>();
            foreach (var question in allQuestion)
            {
                foreach (var id in ids)
                {
                    if (id == question.QuestionId)
                    {
                        result.Add(question);
                    }
                }
            }
            return result;
        }



    }
}
