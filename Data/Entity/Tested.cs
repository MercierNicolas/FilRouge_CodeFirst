using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
    [PrimaryKey(nameof(QuizzId), nameof(IdentityUserId))]
    public class Tested
    {
        // Les deux clés composant la clé composite
        public int QuizzId { get; set; }
        public string IdentityUserId { get; set; }

        // Date de passage du Quizz
        public DateTime TestedDate { get; set; }

        public IdentityUser IdentityUser { get; set; }
        public Quiz Quiz { get; set; }
    }
}
