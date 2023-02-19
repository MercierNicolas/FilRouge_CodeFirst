using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Models
{
    public class QuizPassageViewModel
    {
        public string ContentQuestion { get; set; }
        public string ContentCorection { get; set; }
        public bool IsCorrect { get; set; }

        public string Answers { get; set; }

        public int? NextQuestionId { get; set; } 
        public int TotalQuestions { get; set; } = 20;

        public List<AnswerChoice> AnswerChoice { get; set; }
        public List<Quiz> quizs { get; set; }
        public List<Question> Questions { get; set; }

        public List<string> ListCheckChoice { get; set; }
        


        public int CorrectionId { get; set; }
        public int QuestionId { get; set; }
        public int QuizzId { get; set; }

        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? Average { get; set; }
        public Sujet? Sujet { get; set; }
        public Level? Level { get; set; }
        public string Comment { get; set; }
        public TheAnswer TheAnswer { get; set; }   



    }
}
