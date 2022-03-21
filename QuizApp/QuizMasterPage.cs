using Microsoft.AspNetCore.SignalR.Client;
using QuizApp.Entity.DTO;
using QuizApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class QuizMasterPage : Form
    {
        private ExamDTO examDTO = new ExamDTO();
        private List<QuestionDTO> questionList;
        HubConnection connection;
        private int numberOfCurrentQuestion =0;
        private int totalQuestion =0;
        private List<ButtonKeyDTO> buttonKeyDTOs = new List<ButtonKeyDTO>();
        private List<ParticipantDTO> participantDTOs = new List<ParticipantDTO>();
        private AssignKeyService assignKeyService = new AssignKeyService();
        private ParticipantService participantService = new ParticipantService();
        private QuestionDTO currentQuestion = new QuestionDTO();

        public QuizMasterPage()
        {
            InitializeComponent();
            BuildSignalRConnection();
            buttonKeyDTOs = assignKeyService.GetAll();
            participantDTOs = participantService.GetAll();

            FillSubjects();
        }

        private void BuildSignalRConnection()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7042/quizhub")
            .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            connection.StartAsync();
        }

        public QuizMasterPage(ExamDTO examDTO)
        {
            InitializeComponent();
            BuildSignalRConnection();
            FillSubjects();
            this.examDTO = examDTO;
            totalQuestion = examDTO.QuestionCount;
            buttonKeyDTOs = assignKeyService.GetAll();
            participantDTOs = participantService.GetAll();
        }

        private void FillSubjects()
        {
            questionList = new List<QuestionDTO>();
            questionList.Add(
                new QuestionDTO
                {
                    Id = 1,
                    Subject = "Geography",
                    QuestionText = "Which's capital city of Turkey?",
                    CorrectOption = "Ankara",
                    Options = new List<string> { "Istanbul", "Tokat", "Ankara", "Bayburt" },

                });
            questionList.Add(
               new QuestionDTO
               {
                   Id = 2,
                   Subject = "Geography",
                   QuestionText = "Which's biggest city of Turkey?",
                   CorrectOption = "Istanbul",
                   Options = new List<string> { "Istanbul", "Tokat", "Ankara", "Bayburt" }
               });
            questionList.Add(
              new QuestionDTO
              {
                  Id = 3,
                  Subject = "Math",
                  QuestionText = "2+2?",
                  CorrectOption = "4",
                  Options = new List<string> { "3", "4", "5", "22" }
              });
            questionList.Add(
               new QuestionDTO
               {
                   Id = 4,
                   Subject = "Science",
                   QuestionText = "Which's natural satellite of Earth?",
                   CorrectOption = "Moon",
                   Options = new List<string> { "Moon", "Sun", "Jupiter", "Hubble" }
               });
            //natural satellite of earth

            RadioButton box;
            
            int innitialOffset = 20;
            int xDistance = 200;
            int yDistance = 50;

            //for (int i = 0; i < yourList.Count; i++)
            int i = 0;
            foreach (var item in questionList)
            {
                box = new RadioButton();
                box.Tag = item.Subject;
                box.Name = "question" + item.Id;
                box.Text = "Question: " + item.QuestionText + Environment.NewLine + "Answer  : " + item.CorrectOption;
                box.AutoSize = true;
                //if (yourList.Count < 8)
                box.Location = new Point(innitialOffset + xDistance, innitialOffset + i * yDistance);
                //else if (yourList.Count < 15)
                //    box.Location = new Point(innitialOffset + i % 2 * xDistance, innitialOffset + i / 2 * yDistance);
                //else
                //    box.Location = new Point(innitialOffset + i % 3 * xDistance, innitialOffset + i / 3 * yDistance);

                this.groupSubjects.Controls.Add(box);
                i++;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var selectedQuestion = groupSubjects.Controls.OfType<RadioButton>().Where(c => c.Checked).Select(c => new { c.Text, c.Name, c.Tag }).FirstOrDefault();
            if (selectedQuestion == null)
            {
                MessageBox.Show("Please select a question", "Warning");
                return;
            }

            var questionId = Int32.Parse(selectedQuestion.Name.Split("question")[1]);
            currentQuestion = questionList.FirstOrDefault(x => x.Id == questionId);

            currentQuestion.IsAsked=true;

            QuestionToMonitorDTO questionToMonitorDTO = new QuestionToMonitorDTO
            {
                QuestionText = currentQuestion.QuestionText,
                NumberOfCurrentQuestion = numberOfCurrentQuestion,
                Subject = currentQuestion.Subject,
                TimeToPressButton = examDTO.PressButtonTime,
                ParticipantCount = examDTO.ParticipantCount,
                TotalQuestionCount = examDTO.QuestionCount,
                Options = currentQuestion.Options
            };

            var modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
            if(connection.State==HubConnectionState.Disconnected)
                await connection.StartAsync();

            await connection.InvokeAsync("SendMessage",
                       modelStr);
        }

        private async void QuizMasterPage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void QuizMasterPage_KeyDown(object sender, KeyEventArgs e)
        {
            var buttonKey = buttonKeyDTOs.FirstOrDefault(x => x.Key.ToUpper() == e.KeyData.ToString().ToUpper());
            if (buttonKey != null)
            {
                var participant = participantDTOs.FirstOrDefault(x => x.ButtonNumber == buttonKey.Number);
                if (participant != null)
                {
                    MessageBox.Show(participant.Name + ", pressed the button!", "Answer");

                    QuestionToMonitorDTO questionToMonitorDTO = new QuestionToMonitorDTO
                    {
                        QuestionText = currentQuestion.QuestionText,
                        NumberOfCurrentQuestion = numberOfCurrentQuestion,
                        Subject = currentQuestion.Subject,
                        TimeToPressButton = examDTO.PressButtonTime,
                        ParticipantCount = examDTO.ParticipantCount,
                        TotalQuestionCount = examDTO.QuestionCount,
                        Options = currentQuestion.Options,
                        AnsweredParticipantName = participant.Name
                    };

                    var modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
                    if (connection.State == HubConnectionState.Disconnected)
                        await connection.StartAsync();

                    await connection.InvokeAsync("SendMessage",
                               modelStr);
                }
            }
        }
    }
}
