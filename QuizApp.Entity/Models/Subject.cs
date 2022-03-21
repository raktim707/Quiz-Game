using System;
using System.Collections.Generic;

namespace QuizApp.Entity.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ExamSubjects = new HashSet<ExamSubject>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<ExamSubject> ExamSubjects { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
