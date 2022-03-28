using QuizApp.Entity.DTO;
using QuizApp.Entity.Enums;
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
    public partial class SubjectCountSelectionPage : Form
    {
        private ExamDTO examDTO;
        private SubjectSelectionType subjectSelectionType;

        public SubjectCountSelectionPage()
        {
            InitializeComponent();
        }

        public SubjectCountSelectionPage(ExamDTO examDTO)
        {
            this.examDTO = examDTO;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            subjectSelectionType = SubjectSelectionType.MultipleSelection;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            subjectSelectionType = SubjectSelectionType.SingleSelection;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedQuestion = groupBox2.Controls.OfType<RadioButton>().Where(c => c.Checked).Select(c => new { c.Text, c.Name, c.Tag }).FirstOrDefault();
                if (selectedQuestion == null)
                {
                    MessageBox.Show("Please select a subject type", "Warning");
                    return;
                }

                if (subjectSelectionType == SubjectSelectionType.SingleSelection)
                {
                    this.Hide();
                    Form form = new SubjectSingleSelectionPage(examDTO);
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
                else
                {
                    this.Hide();
                    Form form = new SubjectMultipleSelectionPage(examDTO);
                    form.Closed += (s, args) => this.Close();
                    form.Show();
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
