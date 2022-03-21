using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public partial class Option
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int? QuestiontId { get; set; }
        public bool? IsCorrect { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Question? Questiont { get; set; }
    }
}
