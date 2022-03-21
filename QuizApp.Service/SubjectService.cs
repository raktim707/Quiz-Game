using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;

namespace QuizApp.Service
{
    public class SubjectService
    {
        public SubjectDTO AddSubject(SubjectDTO subjectDTO)
        {
            Repository<Subject> repository = new Repository<Subject>();
            var subject = new Subject
            {
                Name = subjectDTO.Name,
                CreatedDate = DateTime.Now
            };
            repository.Insert(subject);
            var res = new SubjectDTO
            {
                Id = subject.Id,
                Name = subject.Name
            };

            return res;
        }

        public List<SubjectDTO> GetAll()
        {
            Repository<Subject> repository = new Repository<Subject>();
            return repository.List().Include(x => x.Questions).Select(x => new SubjectDTO
            {
                Id = x.Id,
                Name = x.Name,
                QuestionCount = x.Questions.Count
            }).ToList();
        }
    }
}