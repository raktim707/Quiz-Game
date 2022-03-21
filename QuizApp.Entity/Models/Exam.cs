using System;
using System.Collections.Generic;

namespace QuizApp.Entity.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamSubjects = new HashSet<ExamSubject>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int? QuestionCount { get; set; }
        public int? PressButtonTime { get; set; }
        public int? AnswerTime { get; set; }
        public string? MasterName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<ExamSubject> ExamSubjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
