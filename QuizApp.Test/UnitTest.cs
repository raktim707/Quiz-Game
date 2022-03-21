using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCalculateEqualQuestionCount()
        {
            var result = CalculationHelper.CalculateEqualQuestionCount(3, 30);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestCalculateEqualQuestionCountWİthModGreaterThanZero()
        {
            var result = CalculationHelper.CalculateEqualQuestionCount(3, 31);

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void TestCalculateQuestionCountByPercentage()
        {

            List<Entity.DTO.SubjectDTO> list = new List<Entity.DTO.SubjectDTO> {
            new Entity.DTO.SubjectDTO{
            Id=1, Name="Math", QuestionCount=11 },
             new Entity.DTO.SubjectDTO{
            Id=1, Name="Science", QuestionCount=50 },
             new Entity.DTO.SubjectDTO{
            Id=1, Name="Chemistry", QuestionCount=39 }};

            var result = CalculationHelper.CalculateQuestionCountByPercentage(list, 33);

            Assert.AreEqual(4, result[0].QuestionCount);
            Assert.AreEqual(17, result[1].QuestionCount);
            Assert.AreEqual(13, result[2].QuestionCount);
        }
    }
}
