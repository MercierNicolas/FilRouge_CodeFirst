using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilRouge_Test_CodeFirst.Models
{
    public class QuestionViewModel
    {
        public Question question { get; set; }
        public IEnumerable<SelectListItem> AllLevel { get; set; }
        public int LevelId { get; set; }

        public IEnumerable<SelectListItem> AllSujet { get; set; }
        public int sujetId { get; set; }

    }
}
