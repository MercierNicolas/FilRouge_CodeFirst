using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    public class AnswerChoice
    {
        [Key]
        public int CorrectionId { get; set; }
        public string ContentCorection { get; set; }
        public bool IsCorrect { get; set; }
       // public virtual ICollection<Question> Question { get; set; }
        public Question questionId { get; set; }
    }
}
