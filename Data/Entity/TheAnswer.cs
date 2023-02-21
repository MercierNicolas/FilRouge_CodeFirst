using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    public class TheAnswer
    {
        [Key]
        public int TheAnswerId { get; set; }

        public Question QuestionsId { get; set; }

        public int choiceIdUser { get; set; }
        public int QuizId { get; set; }

        public bool IsBonnrep { get; set; }

        
    }
}
