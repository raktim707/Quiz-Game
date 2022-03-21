using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity.DTO
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public int QuestionCount { get; set; }
        public int ParticipantCount { get; set; }
        public int PressButtonTime { get; set; }
        public int AnswerTime { get; set; }
        public string? MasterName { get; set; }
    }
}
