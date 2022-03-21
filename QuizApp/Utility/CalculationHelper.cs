using QuizApp.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Helpers
{
    public static class CalculationHelper
    {
        public static int CalculateEqualQuestionCount(int subjectCount, int totalQuestionCount)
        {
            var mod = totalQuestionCount % subjectCount;
            if (mod == 0)
                return totalQuestionCount / subjectCount;

            totalQuestionCount = totalQuestionCount + subjectCount - mod;
            return totalQuestionCount / subjectCount;
        }

        public static List<SubjectDTO> CalculateQuestionCountByPercentage(List<SubjectDTO> list, int totalQuestionCount)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].QuestionCount = (int)Math.Ceiling((decimal)totalQuestionCount * ((decimal)list[i].QuestionCount / 100));
            }
            var sdf = Math.Ceiling(3.63);
            return list;
        }
        
    }
}
