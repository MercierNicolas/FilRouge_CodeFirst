using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
	public class Quiz
	{
		[Key]
		public int QuizzId { get; set; }
		public string? Name { get; set; }
		public string? Code { get; set; }		
		public int? Average { get; set; }
		public virtual ICollection<Question> Questions { get; set; }
		public Sujet? Sujet { get; set; }
		public Level? Level { get; set; }
		public virtual ICollection<Tested>? Candidats { get; set; }
		public IdentityUser? RecruterId { get; set; }

    }
}
