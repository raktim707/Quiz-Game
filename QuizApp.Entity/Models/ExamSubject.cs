using System;
using System.Collections.Generic;

namespace QuizApp.Entity.Models
{
    public partial class ExamSubject
    {
        public ExamSubject()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
        }

        public int Id { get; set; }
        public int? ExamId { get; set; }
        public int? SubjectId { get; set; }
        public int? QuestionCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
