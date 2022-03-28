using Microsoft.EntityFrameworkCore;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;
using System.Linq.Expressions;

namespace QuizApp.Service
{
    public class QuestionService
    {
        public QuestionDTO AddQuestion(QuestionDTO model)
        {
            Repository<Question> repository = new Repository<Question>();
            var subject = new Question
            {
                SubjectId = model.SubjectId,
                Text = model.QuestionText,
                CreatedDate = DateTime.Now
            };
            repository.Insert(subject);
            model.Id = subject.Id;

            return model;
        }

        public QuestionDTO AddQuestionWithOption(QuestionDTO model)
        {
            Repository<Question> repository = new Repository<Question>();
            OptionService optionService = new OptionService();
            var subject = new Question
            {
                SubjectId = model.SubjectId,
                Text = model.QuestionText,
                CreatedDate = DateTime.Now
            };
            repository.Insert(subject);
            model.Id = subject.Id;

            if (model.Options != null)
            {
                foreach (var option in model.Options)
                {
                    optionService.AddOption(new OptionDTO
                    {
                        QuestiontId = model.Id,
                        Text = option,
                        IsCorrect = option == model.CorrectOption
                    });
                }
            }

            return model;
        }

        public List<QuestionDTO> GetAll(Expression<Func<Question, bool>> filter = null)
        {
            Repository<Question> repository = new Repository<Question>();
            return repository.List(filter).Include(x => x.Subject).Include(x => x.Options).Select(x => new QuestionDTO
            {
                Id = x.Id,
                QuestionText = x.Text,
                SubjectId = x.SubjectId,
                Subject = x.Subject.Name,
                Options = x.Options.Select(x => x.Text).ToList(),
                CorrectOption = x.Options.FirstOrDefault(x => x.IsCorrect == true).Text
            }).ToList();
        }

        public QuestionDTO Get(Expression<Func<Question, bool>> filter)
        {
            Repository<Question> repository = new Repository<Question>();
            return repository.List(filter).Include(x => x.Options).Select(x => new QuestionDTO
            {
                Id = x.Id,
                QuestionText = x.Text,
                SubjectId = x.SubjectId,
                Options = x.Options.Select(x => x.Text).ToList(),
                CorrectOption = x.Options.FirstOrDefault(x => x.IsCorrect == true).Text
            }).FirstOrDefault();
        }
    }
}