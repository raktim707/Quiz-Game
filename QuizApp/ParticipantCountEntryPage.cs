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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class ParticipantCountEntryPage : Form
    {
        private ExamDTO examDTO;
        private ExamService examService = new ExamService();

        public ParticipantCountEntryPage()
        {
            InitializeComponent();
        }

        public ParticipantCountEntryPage(ExamDTO examDTO)
        {
            this.examDTO = examDTO;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("please enter a number of participant", "Warning");
                return;
            }
            else if (!textBox1.Text.IsNumeric())
            {
                MessageBox.Show("please enter a valid number of participant", "Warning");
                return;
            }

            int numberOfParticipant = Int32.Parse(textBox1.Text);

            if (numberOfParticipant < 1)
            {
                MessageBox.Show("please enter a valid number of participant", "Warning");
                return;
            }
            else if (numberOfParticipant > 30)
            {
                MessageBox.Show("please enter a number of participant that less than 30", "Warning");
                return;
            }

            examDTO.ParticipantCount = numberOfParticipant;
            examDTO = examService.AddExam(examDTO);
            this.Hide();
            Form form = new ParticipantsEntryPage(examDTO);
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
