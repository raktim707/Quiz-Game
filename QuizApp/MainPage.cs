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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new AdminPage();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
