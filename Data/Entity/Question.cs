using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilRouge_Test_CodeFirst.Data.Entity
{
	public class Question
	{
		[Key]
		public int QuestionId { get; set; }
		public string ContentQuestion { get; set; }
		public virtual ICollection<Quiz>? Quiz { get; set; }
		public Sujet Sujet { get; set; }
		public Level Level { get; set; }
        public virtual ICollection<AnswerChoice> AnswerChoice { get; set; }


    }
}
