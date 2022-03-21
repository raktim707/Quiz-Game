using Microsoft.AspNetCore.SignalR.Client;
using QuizApp.Monitor.Models;
using System.Text.Json;

namespace QuizApp.Monitor
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        private string[] optionsPrefixes = { "A - ", "B - ", "C - ", "D - ", "E - ", "F - ", "G - ", "H - ", "I - ", "J - " };
        private int secondsToPressButton = 0;
        private int secondsToAnswer = 0;

        private DateTime startTime;
        private DateTime startTimeToAnswer;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerToAnswer = new System.Windows.Forms.Timer();
        private QuestionDTO currentQuestion;


        public Form1()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7042/quizhub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            timer.Tick += new EventHandler(timer_Tick);
            timerToAnswer.Tick += new EventHandler(timer_TickAnswer);

            connection.On<string>("ReceiveMessage", (message) =>
            {
                this.Invoke((Action)(() =>
                {
                    currentQuestion = JsonSerializer.Deserialize<QuestionDTO>(message);
                    FillFields(currentQuestion);
                }));
            });
            connection.StartAsync();
        }
   
        private void StartButtonTimer()
        {
            timer.Start(); // start timer (you can do it on form load, if you need)
            startTime = DateTime.Now; // and remember start time
        }

        private void StartAnswerTimer()
        {
            timerToAnswer.Start(); // start timer (you can do it on form load, if you need)
            startTimeToAnswer = DateTime.Now; // and remember start time
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = secondsToPressButton - elapsedSeconds;

            if (remainingSeconds <= 0)
            {
                // run your function
                timer.Stop();
            }

            labelCountdownToPress.Text = remainingSeconds.ToString();
            //    String.Format("{0} seconds remaining...", remainingSeconds);
        }

        private void timer_TickAnswer(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = secondsToAnswer - elapsedSeconds;

            if (remainingSeconds <= 0)
            {
                // run your function
                timerToAnswer.Stop();
            }

            labelCountdownToAnswer.Text = remainingSeconds.ToString();
            //    String.Format("{0} seconds remaining...", remainingSeconds);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            connection.On<string>("ReceiveMessage", (message) =>
            {
                this.Invoke((Action)(() =>
                {
                    currentQuestion = JsonSerializer.Deserialize<QuestionDTO>(message);
                    FillFields(currentQuestion);
                }));
            });
            await connection.StartAsync();
        }

        private void FillFields(QuestionDTO currentQuestion)
        {
            labelSubject.Text = currentQuestion.Subject;
            labelQuestion.Text = currentQuestion.QuestionText;
            labelOptions.Text = "";
            for (int i = 0; i<currentQuestion.Options.Count;i++)
            {
                labelOptions.Text += optionsPrefixes[i] + currentQuestion.Options[i] + Environment.NewLine;
            }
            labelNumberOfParticipants.Text = currentQuestion.ParticipantCount.ToString();
            labelNumberofQuestions.Text = currentQuestion.NumberOfCurrentQuestion + "/" + currentQuestion.TotalQuestionCount;
            
            if(!string.IsNullOrEmpty(currentQuestion.AnsweredParticipantName))
            {
                labelAnsweredParticipant.Text = currentQuestion.AnsweredParticipantName;
                secondsToAnswer = currentQuestion.TimeToAnswer;
                groupBoxAnswer.Enabled = true;
                timer.Stop();
                StartAnswerTimer();
            }
            else
            {
                secondsToPressButton = currentQuestion.TimeToPressButton;
                groupBoxAnswer.Enabled = false;
                StartButtonTimer();
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    await connection.InvokeAsync("SendMessage",
                        "cevap", "fffff");
                }
                catch (Exception ex)
                {
                    //messagesList.Items.Add(ex.Message);
                }
            }
        }
    }
}