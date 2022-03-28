using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity.DTO
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int? QuestiontId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
