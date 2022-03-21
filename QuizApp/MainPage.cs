using Microsoft.AspNetCore.SignalR.Client;
using QuizApp.Entity.DTO;
using System.Text.Json;

namespace QuizApp
{
    public partial class MainPage : Form
    {
        HubConnection connection;
        public MainPage()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder().WithUrl("https://localhost:7042/quizhub")
              .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new QuizMasterEntryPage();
            form.Closed += (s, args) => this.Close();
            form.Show();
            //QuestionToMonitorDTO questionToMonitorDTO = new QuestionToMonitorDTO
            //{
            //    QuestionText = "Türkiye'nin baþkenti?",
            //    NumberOfCurrentQuestion = 1,
            //    Subject = "Coðrafya",
            //    TimeToPressButton = 60,
            //    ParticipantCount = 10,
            //    TotalQuestionCount = 23,
            //    Options = new List<string>
            //    {
            //        "Tokat",
            //        "Bayburt",
            //        "Burdur",
            //        "Ankara"
            //    }
            //};
            
            //var modelStr = JsonSerializer.Serialize(questionToMonitorDTO);
            //await connection.StartAsync();
            //await connection.InvokeAsync("SendMessage",
            //           modelStr);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new QuizMasterPage();
            //Form form = new AdminPage();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
