using QuizApp.Entity.DTO;
using QuizApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Linq.Extensions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class SubjectSingleSelectionPage : Form
    {
        private ExamDTO examDTO;
        private SubjectService subjectService = new SubjectService();
        private List<SubjectDTO> subjectDTOs = new List<SubjectDTO>();

        public SubjectSingleSelectionPage()
        {
            InitializeComponent();

            FillSubjects();
        }

        private void FillSubjects()
        {
            try
            {
                subjectDTOs = subjectService.GetAll();

                RadioButton box;

                int innitialOffset = 20;
                int xDistance = 200;
                int yDistance = 50;
                int i = 0;

                foreach (var subject in subjectDTOs)
                {
                    box = new RadioButton();
                    box.Tag = subject.Name;
                    box.Name = "subject" + subject.Id;
                    box.Text = subject.Name;
                    box.AutoSize = true;
                    if (subjectDTOs.Count < 8)
                        box.Location = new Point(innitialOffset + xDistance, innitialOffset + i * yDistance);
                    else if (subjectDTOs.Count < 15)
                        box.Location = new Point(innitialOffset + i % 2 * xDistance, innitialOffset + i / 2 * yDistance);
                    else
                        box.Location = new Point(innitialOffset + i % 3 * xDistance, innitialOffset + i / 3 * yDistance);

                    this.groupSubjects.Controls.Add(box);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public SubjectSingleSelectionPage(ExamDTO examDTO)
        {
            InitializeComponent();
            FillSubjects();
            this.examDTO = examDTO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = groupSubjects.Controls.OfType<RadioButton>().Where(c => c.Checked).Select(c => new { c.Text, c.Name, c.Tag }).ToList();

                if (selected == null || selected.Count == 0)
                {
                    MessageBox.Show("Please select a subject", "Warning");
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxQuestionCount.Text))
                {
                    MessageBox.Show("Please enter question count", "Warning");
                    return;
                }

                int subjectId = int.Parse(selected.FirstOrDefault().Name.Replace("subject", ""));
                int questionCount = int.Parse(textBoxQuestionCount.Text);

                examDTO.QuestionCount = questionCount;
                examDTO.Subjects.Add(new SubjectDTO { Id = subjectId, Name = selected.FirstOrDefault().Text, QuestionCount = questionCount });

                this.Hide();
                Form form = new SetTimersPage(examDTO);
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBoxQuestionCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
