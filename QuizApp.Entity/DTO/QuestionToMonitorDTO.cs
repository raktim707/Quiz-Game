using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity.DTO
{
    public class QuestionToMonitorDTO
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string Subject { get; set; }
        public List<string> Options { get; set; }
        public int ParticipantCount { get; set; }
        public int NumberOfCurrentQuestion { get; set; }
        public int TotalQuestionCount { get; set; }
        public int TimeToPressButton { get; set; }
        public int TimeToAnswer { get; set; }
        public string AnsweredParticipantName { get; set; }
        public bool IsPressedButton { get; set; }
    }
}
