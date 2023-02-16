using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Models
{
    public class AddQuestionQuizViewModel
    {
        public Quiz QuizAddQuestion { get; set; }
        public Question Question { get; set; }
        public List<Question> QuestionList { get; set; }
        public bool IsCheck { get; set; }
        public List<int> IsCheckedQuestionID { get; set; }

    }
}
