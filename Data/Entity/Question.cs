using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
	public class Question
	{
		[Key]
		public int QuestionId { get; set; }
		public string Content { get; set; }
		public virtual ICollection<Quiz>? Quiz { get; set; }
		public Sujet Sujet { get; set; }
		public Level Level { get; set; }
        public virtual ICollection<Correction> Correction { get; set; }
		public string Choix1 { get; set; }
        public string Choix2 { get; set; }
        public string Choix3 { get; set; }
        public string Choix4 { get; set; }


    }
}
