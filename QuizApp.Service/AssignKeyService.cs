using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;

namespace QuizApp.Service
{
    public class AssignKeyService
    {
        public ButtonKeyDTO AddButtonKey(ButtonKeyDTO subjectDTO)
        {
            Repository<ButtonKey> repository = new Repository<ButtonKey>();
            var subject = new ButtonKey
            {
                Key = subjectDTO.Key,
                Number = subjectDTO.Number,
                CreatedDate = DateTime.Now
            };
            repository.Insert(subject);
            var res = new ButtonKeyDTO
            {
                Id = subject.Id,
                Key = subject.Key,
                Number = subjectDTO.Number
            };

            return res;
        }

        public List<ButtonKeyDTO> GetAll()
        {
            Repository<ButtonKey> repository = new Repository<ButtonKey>();
            return repository.List().Select(x => new ButtonKeyDTO
            {
                Id = x.Id,
                Key = x.Key,
                Number = x.Number.Value
            }).ToList();
        }
    }
}