using System;
using System.Collections.Generic;

namespace QuizApp.Entity.Models
{
    public partial class ButtonKey
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string? Key { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
