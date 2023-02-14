using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    [PrimaryKey(nameof(TheAnswerId), nameof(IdentityUserId))]
    public class Valided
    {
        // Les deux clés composant la clé composite
        public int TheAnswerId { get; set; }
        public string IdentityUserId { get; set; }

        // Date de validation
        public DateTime ValidedDate { get; set; }

        public IdentityUser IdentityUser { get; set; }
        public virtual ICollection<TheAnswer>? TheAnswers { get; set; }
    }
}
