using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    public class TheAnswer
    {
        [Key]
        public int TheAnswerId { get; set; }

        public Question QuestionsId { get; set; }
<<<<<<< HEAD

        public int choiceIdUser { get; set; }
        public int QuizId { get; set; }
        public bool IsBonnrep { get; set; }
=======

        public int choiceIdUser { get; set; }
        public int QuizId { get; set; }
        public bool IsBonnrep { get; set; }

>>>>>>> 82c7831c1ca01a7333267e1c1ee3eba7cb4f99e4
        
    }
}
