using QuizApp.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class QuizMasterEntryPage : Form
    {
        public QuizMasterEntryPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a name", "Warning");
                return;
            }
            ExamDTO examDTO = new ExamDTO();
            examDTO.MasterName = textBox1.Text;

            this.Hide();
            Form form = new ParticipantCountEntryPage(examDTO);
            form.Closed += (s, args) => this.Close();
            form.Show();

        }
    }
}
