using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public partial class ExamQuestion
    {
        public int Id { get; set; }
        public int? ExamSubjectId { get; set; }
        public int? QuestionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ExamSubject? ExamSubject { get; set; }
        public virtual Question? Question { get; set; }
    }
}
