using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.Models;

namespace QuizApp.Test
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void TestAddSubject()
        {
            Repository<Subject> repository = new Repository<Subject>();
            var subject = new Subject
            {
                Name = "Test Subject"
            };
            var res = repository.Insert(subject);

            Assert.IsTrue(res);
            Assert.IsTrue(subject.Id > 0);

            repository.Delete(subject);
        }
    }
}