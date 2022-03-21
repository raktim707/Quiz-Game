using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public partial class Question
    {
        public Question()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
            Options = new HashSet<Option>();
        }

        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int? SubjectId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
