using QuizApp.Entity.DTO;
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
    public partial class SetTimersPage : Form
    {
        private ExamDTO examDTO;
        private ExamService examService= new ExamService();
        public SetTimersPage()
        {
            InitializeComponent();
        }

        public SetTimersPage(ExamDTO examDTO)
        {
            InitializeComponent();
            this.examDTO = examDTO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxNoSPressButton.Text))
            {
                MessageBox.Show("number of seconds to press button field cannot be empty");
                return;
            }
            else if (string.IsNullOrEmpty(textBoxNoSAnswer.Text))
            {
                MessageBox.Show("number of seconds to answer field cannot be empty");
                return;
            }
            else
            {
                examDTO.AnswerTime= int.Parse(textBoxNoSAnswer.Text);
                examDTO.PressButtonTime= int.Parse(textBoxNoSPressButton.Text);

                examDTO = examService.UpdateExam(examDTO);

                this.Hide();
                Form form = new QuizMasterPage(examDTO);
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
        }

        private void textBoxNoSPressButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }

        private void textBoxNoSAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
