using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApp.Data.EntityFramework;
using QuizApp.Entity.DTO;
using QuizApp.Entity.Models;
using QuizApp.Service;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestAddQuestions()
        {
            List<QuestionDTO> questionList = new List<QuestionDTO>();
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 5,
                  Subject = "Geography",
                  QuestionText = "Which's capital city of Turkey?",
                  CorrectOption = "Ankara",
                  Options = new List<string> { "Istanbul", "Tokat", "Ankara", "Bayburt" },

              });
            questionList.Add(
               new QuestionDTO
               {
                  SubjectId = 5,
                   Subject = "Geography",
                   QuestionText = "Which's biggest city of Turkey?",
                   CorrectOption = "Istanbul",
                   Options = new List<string> { "Istanbul", "Tokat", "Ankara", "Bayburt" }
               });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "2+2?",
                  CorrectOption = "4",
                  Options = new List<string> { "3", "4", "5", "22" }
              });
            questionList.Add(
               new QuestionDTO
               {
                  SubjectId = 3,
                   Subject = "Science",
                   QuestionText = "Which's natural satellite of Earth?",
                   CorrectOption = "Moon",
                   Options = new List<string> { "Moon", "Sun", "Jupiter", "Hubble" }
               });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 1,
                 Subject = "Math",
                 QuestionText = "121 Divided by 11 is ",
                 CorrectOption = "11",
                 Options = new List<string> { "11", "10", "19", "18" }
             }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "60 Times of 8 Equals to",
                  CorrectOption = "480",
                  Options = new List<string> { "480", "300", "250", "400" }
              }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "Find the Missing Term in Multiples of 6 : 6, 12, 18, 24, _, 36, 42, _ 54, 60.",
                  CorrectOption = "30, 48",
                  Options = new List<string> { "32, 45", "30, 48", "24, 40", "25, 49" }
              }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "What is the Next Prime Number after 7 ?",
                  CorrectOption = "11",
                  Options = new List<string> { "13", "12", "14", "11" }
              }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "The Product of 131 × 0 × 300 × 4",
                  CorrectOption = "0",
                  Options = new List<string> { "11", "0", "46", "45" }
              }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "Solve 3 + 6 × ( 5 + 4) ÷ 3 - 7",
                  CorrectOption = "14",
                  Options = new List<string> { "11", "16", "14", "15" }
              }); 
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "Solve 23 + 3 ÷ 3",
                  CorrectOption = "24",
                  Options = new List<string> { "24", "25", "26", "27" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "How Many Years are there in a Decade?",
                  CorrectOption = "10 years",
                  Options = new List<string> { "5 years", "10 years", "15 years", "20 years" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "How Many Months Make a Century?",
                  CorrectOption = "1200",
                  Options = new List<string> { "12", "120", "1200", "12000" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "Priya had 16 Red Balls, 2 Green Balls, 9  Blue Balls, and 1 Multicolor Ball. If He Lost 9 Red Balls, 1 Green Ball, and 3 Blue Balls. How Many Balls would be Left?",
                  CorrectOption = "15",
                  Options = new List<string> { "15", "11", "28", "39" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "Add the Decimals 5.23 + 8.79",
                  CorrectOption = "14.02",
                  Options = new List<string> { "14.02", "14.19", "14.11", "14.29" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "How Many Sides are there in a Decagon?",
                  CorrectOption = "10",
                  Options = new List<string> { "7", "8", "9", "10" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "How Many Months Have 120 Days?",
                  CorrectOption = "4 months",
                  Options = new List<string> { "2 months", "4 months", "11 months", "12 months" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 1,
                  Subject = "Math",
                  QuestionText = "What Number Comes Before 9019?",
                  CorrectOption = "None of these",
                  Options = new List<string> { "9099", "9091", "9109", "9099" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Brass gets discoloured in air because of the presence of which of the following gases in air?",
                  CorrectOption = "Hydrogen sulphide",
                  Options = new List<string> { "Oxygen", "Hydrogen sulphide", "Carbon dioxide", "Nitrogen" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Which of the following is a non metal that remains liquid at room temperature?",
                  CorrectOption = "Bromine",
                  Options = new List<string> { "Phosphorous", "Bromine", "Chlorine", "Helium" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Chlorophyll is a naturally occurring chelate compound in which central metal is",
                  CorrectOption = "magnesium",
                  Options = new List<string> { "magnesium", "copper", "iron", "calcium" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Which of the following is used in pencils?",
                  CorrectOption = "Graphite",
                  Options = new List<string> { "Graphite", "Silicon", "Charcoal", "Phosphorous" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Which of the following metals forms an amalgam with other metals ? ",
                  CorrectOption = "Mercury",
                  Options = new List<string> { "Tin", "Mercury", "Lead", "Zinc" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "The gas usually filled in the electric bulb is",
                  CorrectOption = "nitrogen",
                  Options = new List<string> { "nitrogen", "hydrogen", "carbon dioxide", "oxygen" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Washing soda is the common name for",
                  CorrectOption = "Sodium carbonate",
                  Options = new List<string> { "Sodium carbonate", "Calcium bicarbonate", "Sodium bicarbonate", "Calcium carbonate" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Quartz crystals normally used in quartz clocks etc. is chemically",
                  CorrectOption = "silicon dioxide",
                  Options = new List<string> { "germanium oxide", "a mixture of germanium oxide and silicon dioxide", "sodium silicate", "silicon dioxide" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Which of the gas is not known as green house gas?",
                  CorrectOption = "Hydrogen",
                  Options = new List<string> { "Methane", "Nitrous oxide", "Carbon dioxide", "Hydrogen" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Bromine is a",
                  CorrectOption = "red liquid",
                  Options = new List<string> { "black solid", "red liquid", "colourless gas", "highly inflammable gas" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "The hardest substance available on earth is",
                  CorrectOption = "Diamond",
                  Options = new List<string> { "Gold", "Iron", "Diamond", "Platinum" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "The variety of coal in which the deposit contains recognisable traces of the original plant material is",
                  CorrectOption = "peat",
                  Options = new List<string> { "bitumen", "anthracite", "lignite", "peat" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Wha",
                  CorrectOption = "None",
                  Options = new List<string> { "9099", "9091", "9109", "9099" }
              });
            questionList.Add(
              new QuestionDTO
              {
                  SubjectId = 4,
                  Subject = "Chemistry",
                  QuestionText = "Tetraethyl lead is used as",
                  CorrectOption = "petrol additive",
                  Options = new List<string> { "pain killer", "fire extinguisher", "mosquito repellent", "petrol additive" }
              });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "What is the unit for measuring the amplitude of a sound?",
                 CorrectOption = "Decibel",
                 Options = new List<string> { "Decibel", "Coulomb", "Hum", "Cycles" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "Reading of a barometer going down is an indication of",
                 CorrectOption = "rainfall",
                 Options = new List<string> { "snow", "storm", "intense heat", "rainfall" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "Decibel is the unit for",
                 CorrectOption = "intensity of sound",
                 Options = new List<string> { "speed of light", "radio wave frequency", "intensity of sound", "intensity of heat" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "One fathom is equal to",
                 CorrectOption = "6 feet",
                 Options = new List<string> { "6 feet", "6 meters", "60 feet", "100 cm" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "Fathom is the unit of",
                 CorrectOption = "depth",
                 Options = new List<string> { "sound", "depth", "frequency", "distance" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "Light year is a measurement of",
                 CorrectOption = "Stellar distances",
                 Options = new List<string> { "speed of aeroplanes", "speed of light", "Stellar distances", "speed of rockets" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "Very small time intervals are accurately measure by",
                 CorrectOption = "Atomic clocks",
                 Options = new List<string> { "White dwarfs", "Quartz clocks", "Atomic clocks", "Pulsars" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "One kilometre is equal to how many miles?",
                 CorrectOption = "0.62",
                 Options = new List<string> { "0.84", "0.5", "1.6", "0.62" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "One horse power is equal to",
                 CorrectOption = "746 watts",
                 Options = new List<string> { "746 watts", "748 watts", "756 watts", "736 watts" }
             });
            questionList.Add(
             new QuestionDTO
             {
                 SubjectId = 3,
                 Subject = "Science",
                 QuestionText = "kilohertz is a unit which measures",
                 CorrectOption = "electromagnetic radio wave frequencies",
                 Options = new List<string> { "power used by a current of one ampere", "electromagnetic radio wave frequencies", "voltage", "electric resistance" }
             });

            QuestionService questionService = new QuestionService();
             foreach(var question in questionList)
            {
                questionService.AddQuestionWithOption(question);
            }



        }
    }
}