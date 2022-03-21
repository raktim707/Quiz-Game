using QuizApp.Entity.DTO;
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

        public SubjectSingleSelectionPage()
        {
            InitializeComponent();

            FillSubjects();
        }

        private void FillSubjects()
        {
            List<string> yourList = new List<string>();
            yourList.Add("Math");
            yourList.Add("Science");
            yourList.Add("Geography");
            yourList.Add("Chemistry");
            RadioButton box;
           
            int innitialOffset = 20;
            int xDistance = 200;
            int yDistance = 50;

            for (int i = 0; i < yourList.Count; i++)
            {
                box = new RadioButton();
                box.Tag = yourList[i];
                box.Name = "subject" + i;
                box.Text = yourList[i].ToString();
                box.AutoSize = true;
                if (yourList.Count < 8)
                    box.Location = new Point(innitialOffset + xDistance, innitialOffset + i * yDistance);
                else if (yourList.Count < 15)
                    box.Location = new Point(innitialOffset + i % 2 * xDistance, innitialOffset + i / 2 * yDistance);
                else
                    box.Location = new Point(innitialOffset + i % 3 * xDistance, innitialOffset + i / 3 * yDistance);

                this.groupSubjects.Controls.Add(box);
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
            var g = groupSubjects.Controls.OfType<RadioButton>().Where(c => c.Checked).Select(c=> new { c.Text, c.Name, c.Tag}).ToList();

            this.Hide();
            Form form = new SetTimersPage(examDTO);
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
