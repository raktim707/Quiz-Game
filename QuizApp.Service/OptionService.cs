using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;
using System.Linq.Expressions;

namespace QuizApp.Service
{
    public class OptionService
    {
        public OptionDTO AddOption(OptionDTO model)
        {
            Repository<Option> repository = new Repository<Option>();
            var subject = new Option
            {
                IsCorrect = model.IsCorrect,
                QuestiontId = model.QuestiontId,
                Text = model.Text,
                CreatedDate = DateTime.Now
            };
            repository.Insert(subject);
            model.Id = subject.Id;

            return model;
        }

        public List<OptionDTO> GetAll(Expression<Func<Option, bool>> filter = null)
        {
            Repository<Option> repository = new Repository<Option>();
            return repository.List().Include(x => x.Questions).Select(x => new OptionDTO
            {
                Id = x.Id,
                Text = x.Text,
                QuestiontId = x.QuestiontId,
                IsCorrect = x.IsCorrect ?? false
            }).ToList();
        }

        public OptionDTO Get(Expression<Func<Option, bool>> filter)
        {
            Repository<Option> repository = new Repository<Option>();
            return repository.List(filter).Select(x => new OptionDTO
            {
                Id = x.Id,
                Text = x.Text,
                QuestiontId = x.QuestiontId,
                IsCorrect = x.IsCorrect ?? false
            }).FirstOrDefault();
        }
    }
}