using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string text) => double.TryParse(text, out _);

    }
}
