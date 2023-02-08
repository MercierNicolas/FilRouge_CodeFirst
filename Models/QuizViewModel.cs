namespace FilRouge_Test_CodeFirst.Models

{
    using FilRouge_Test_CodeFirst.Data.Entity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using static FilRouge_Test_CodeFirst.Data.Entity.Level;
    using static FilRouge_Test_CodeFirst.Data.Entity.Quiz;
    public class QuizViewModel
    {
        public Quiz Quiz { get; set; }
        public IEnumerable<SelectListItem> AllLevel { get; set; }
        public int LevelId { get; set; }

        public IEnumerable<SelectListItem> AllSujet { get; set; }
        public int sujetId { get; set; }
    }
}
