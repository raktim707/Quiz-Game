using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;

namespace QuizApp.Service
{
    public class ParticipantService
    {
        public ParticipantDTO AddParticipant(ParticipantDTO participanttDTO)
        {
            Repository<Student> repository = new Repository<Student>();
            var student = new Student
            {
                Name = participanttDTO.Name,ButtonNumber = participanttDTO.ButtonNumber,
                ExamId = participanttDTO.ExamId,
                CreatedDate = DateTime.Now
            };
            repository.Insert(student);
            var res = new ParticipantDTO
            {
                Id = student.Id,
                Name = student.Name,
                ExamId = student.ExamId,
                ButtonNumber=student.ButtonNumber,
            };

            return res;
        }

        public List<ParticipantDTO> GetAll()
        {
            Repository<Student> repository = new Repository<Student>();
            return repository.List().Select(x => new ParticipantDTO
            {
                Id = x.Id,
                Name = x.Name,
                ButtonNumber = x.ButtonNumber,
                ExamId= x.ExamId
            }).ToList();
        }
    }
}