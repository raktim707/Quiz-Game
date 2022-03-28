using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public string Subject { get; set; }
        public string CorrectOption { get; set; }
        public List<string> Options { get; set; }
        public bool IsAsked { get; set; }
    }
}
