using Microsoft.AspNetCore.SignalR.Client;
using QuizApp.Entity.DTO;
using QuizApp.Extensions;
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
        private int numberOfCurrentQuestion = 0;
        private int totalQuestion = 0;
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

            FillQuestions(new List<QuestionDTO>());
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
            SetQuestions(examDTO.Subjects);
            FillQuestions(questionList);

            this.examDTO = examDTO;
            totalQuestion = examDTO.QuestionCount;
            buttonKeyDTOs = assignKeyService.GetAll();
            participantDTOs = participantService.GetAll();
        }

        private void SetQuestions(IEnumerable<SubjectDTO> subjects)
        {
            SubjectService subjectService = new SubjectService();
            QuestionService questionService = new QuestionService();
            questionList = new List<QuestionDTO>();

            foreach (SubjectDTO subject in subjects)
            {
                var questions = questionService.GetAll(x => x.SubjectId == subject.Id);
                if (questions != null)
                    questionList.AddRange(questions.Shuffle().PickRandom(subject.QuestionCount));
            }
        }

        private void FillQuestions(List<QuestionDTO> questionList)
        {
            try
            {

                RadioButton radio;

                int innitialOffset = 20;
                int xDistance = 200;
                int yDistance = 50;

                //for (int i = 0; i < yourList.Count; i++)
                int i = 0;
                foreach (var item in questionList)
                {
                    radio = new RadioButton();
                    flowLayoutPanel1.ScrollControlIntoView(radio);
                    radio.Tag = item.Subject;
                    radio.Name = "question" + item.Id;
                    radio.Text = "Question: " + item.QuestionText + Environment.NewLine + "Answer  : " + item.CorrectOption;
                    radio.AutoSize = true;
                    //if (yourList.Count < 8)
                    radio.Location = new Point(innitialOffset + xDistance, innitialOffset + i * yDistance);
                    //else if (yourList.Count < 15)
                    //    box.Location = new Point(innitialOffset + i % 2 * xDistance, innitialOffset + i / 2 * yDistance);
                    //else
                    //    box.Location = new Point(innitialOffset + i % 3 * xDistance, innitialOffset + i / 3 * yDistance);

                    this.flowLayoutPanel1.Controls.Add(radio);
                    i++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedQuestion = flowLayoutPanel1.Controls.OfType<RadioButton>().Where(c => c.Checked).Select(c => new { c.Text, c.Name, c.Tag }).FirstOrDefault();
                if (selectedQuestion == null)
                {
                    MessageBox.Show("Please select a question", "Warning");
                    return;
                }
                numberOfCurrentQuestion++;
                var questionId = Int32.Parse(selectedQuestion.Name.Replace("question", ""));
                currentQuestion = questionList.FirstOrDefault(x => x.Id == questionId);

                currentQuestion.IsAsked = true;
                string topScorer = participantDTOs.OrderByDescending(x => x.Score).Select(x => x.Name + " (" + x.Score + ")").FirstOrDefault();

                QuestionToMonitorDTO questionToMonitorDTO = new QuestionToMonitorDTO
                {
                    QuestionText = currentQuestion.QuestionText,
                    NumberOfCurrentQuestion = numberOfCurrentQuestion,
                    Subject = currentQuestion.Subject,
                    TimeToPressButton = examDTO.PressButtonTime,
                    TimeToAnswer = examDTO.AnswerTime,
                    ParticipantCount = examDTO.ParticipantCount,
                    TotalQuestionCount = examDTO.QuestionCount,
                    Options = currentQuestion.Options,
                    TopScorer = topScorer,
                    IsAnswered = false
                };

                var modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
                if (connection.State == HubConnectionState.Disconnected)
                    await connection.StartAsync();

                await connection.InvokeAsync("SendMessage",
                           modelStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private async void QuizMasterPage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void QuizMasterPage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var buttonKey = buttonKeyDTOs.FirstOrDefault(x => x.Key.ToUpper() == e.KeyData.ToString().ToUpper());
                if (buttonKey != null)
                {
                    var participant = participantDTOs.FirstOrDefault(x => x.ButtonNumber == buttonKey.Number && x.ExamId == examDTO.Id);
                    if (participant != null)
                    {


                        flowLayoutPanel1.Controls.Clear();

                        FillQuestions(questionList.Where(x => x.IsAsked == false).ToList());
                        string topScorer = participantDTOs.OrderByDescending(x => x.Score).Select(x => x.Name + " (" + x.Score + ")").FirstOrDefault();
                        QuestionToMonitorDTO questionToMonitorDTO = new QuestionToMonitorDTO
                        {
                            QuestionText = currentQuestion.QuestionText,
                            NumberOfCurrentQuestion = numberOfCurrentQuestion,
                            Subject = currentQuestion.Subject,
                            TimeToPressButton = examDTO.PressButtonTime,
                            TimeToAnswer = examDTO.AnswerTime,
                            ParticipantCount = examDTO.ParticipantCount,
                            TotalQuestionCount = examDTO.QuestionCount,
                            Options = currentQuestion.Options,
                            AnsweredParticipantName = participant.Name,
                            TopScorer = topScorer,
                            IsAnswered = false
                        };

                        var modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
                        if (connection.State == HubConnectionState.Disconnected)
                            await connection.StartAsync();

                        await connection.InvokeAsync("SendMessage", modelStr);

                        var dialogResult = MessageBox.Show(participant.Name + ", pressed the button! Is the answer is correct?", "Answer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            participant.Score++;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            participant.Score--;
                        }

                        topScorer = participantDTOs.OrderByDescending(x => x.Score).Select(x => x.Name + " (" + x.Score + ")").FirstOrDefault();
                        questionToMonitorDTO = new QuestionToMonitorDTO
                        {
                            QuestionText = currentQuestion.QuestionText,
                            NumberOfCurrentQuestion = numberOfCurrentQuestion,
                            Subject = currentQuestion.Subject,
                            TimeToPressButton = examDTO.PressButtonTime,
                            TimeToAnswer = examDTO.AnswerTime,
                            ParticipantCount = examDTO.ParticipantCount,
                            TotalQuestionCount = examDTO.QuestionCount,
                            Options = currentQuestion.Options,
                            AnsweredParticipantName = participant.Name,
                            TopScorer = topScorer,
                            IsAnswered = true
                        };

                        modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
                        if (connection.State == HubConnectionState.Disconnected)
                            await connection.StartAsync();

                        await connection.InvokeAsync("SendMessage", modelStr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
