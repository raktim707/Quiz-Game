using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Monitor.Models
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ButtonNumber { get; set; }
        public int? ExamId { get; set; }
        public int Score { get; set; } = 0;
    }
}
