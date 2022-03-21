using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;

namespace QuizApp.Service
{
    public class ExamService
    {
        public ExamDTO AddExam(ExamDTO examDTO)
        {
            Repository<Exam> repository = new Repository<Exam>();
            var entity = new Exam
            {
                MasterName = examDTO.MasterName,
                AnswerTime = examDTO.AnswerTime,
                PressButtonTime = examDTO.PressButtonTime,
                QuestionCount = examDTO.QuestionCount,
                CreatedDate = DateTime.Now
            };
            repository.Insert(entity);
            examDTO.Id = entity.Id;

            return examDTO;
        }

        public ExamDTO UpdateExam(ExamDTO examDTO)
        {
            Repository<Exam> repository = new Repository<Exam>();
            var currentExam = repository.Get(x => x.Id == examDTO.Id);

            currentExam.MasterName = examDTO.MasterName;
            currentExam.AnswerTime = examDTO.AnswerTime;
            currentExam.PressButtonTime = examDTO.PressButtonTime;
            currentExam.QuestionCount = examDTO.QuestionCount;
            currentExam.LastModifiedDate = DateTime.Now;
            
            repository.Update(currentExam);           

            return examDTO;
        }

        public List<ExamDTO> GetAll()
        {
            Repository<Exam> repository = new Repository<Exam>();
            return repository.List().Include(x => x.Students).Select(x => new ExamDTO
            {
                Id = x.Id,
                AnswerTime = x.AnswerTime.Value,
                ParticipantCount = x.Students.Count(),
                MasterName = x.MasterName,
                PressButtonTime = x.PressButtonTime.Value,
                QuestionCount = x.QuestionCount.Value
            }).ToList();
        }
    }
}