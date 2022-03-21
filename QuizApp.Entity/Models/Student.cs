using System;
using System.Collections.Generic;

namespace QuizApp.Entity.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ButtonNumber { get; set; }
        public int? ExamId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Exam? Exam { get; set; }
    }
}
