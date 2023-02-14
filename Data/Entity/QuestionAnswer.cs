using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    [PrimaryKey(nameof(QuestionId), nameof(TheAnswerId), nameof(IdentityUserId))]
    public class QuestionAnswer
    {
        // Les trois clés composant la clé composite
        public int QuestionId { get; set; }
        public int TheAnswerId { get; set; }
        public string IdentityUserId { get; set; }

        // Date de validation des reponses
        public DateTime? DateValidation { get; set;}
        public IdentityUser IdentityUser { get; set; }
        public virtual ICollection<TheAnswer>? TheAnswers { get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
    }
}
