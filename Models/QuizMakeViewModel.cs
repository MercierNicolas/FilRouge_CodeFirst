using FilRouge_Test_CodeFirst.Data.Entity;

namespace FilRouge_Test_CodeFirst.Models
{
    public class QuizMakeViewModel
    {
        public Quiz Quiz { get; set; }
        public Question question { get; set; }
        public List<TheAnswer> answerUser { get; set; }
        public double Note { get; set; }

        

    }
}
