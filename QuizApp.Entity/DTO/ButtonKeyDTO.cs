using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Entity.DTO
{
    public class ButtonKeyDTO
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public int Number { get; set; }
    }
}
