namespace FilRouge_Test_CodeFirst.Data.Entity
{
    public class Correction
    {
        public int CorrectionId { get; set; }
        public string ContentCorection { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
