using QuizApp.Entity.DTO;
using QuizApp.Helpers;
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
    public partial class SubjectMultipleSelectionPage : Form
    {
        private ExamDTO examDTO;
        private SubjectService subjectService = new SubjectService();
        private List<SubjectDTO> subjectDTOs = new List<SubjectDTO>();
        private List<SubjectDTO> selectedSubjects;

        public SubjectMultipleSelectionPage()
        {
            InitializeComponent();

            FillSubjects();
        }

        private void FillSubjects()
        {
            subjectDTOs = subjectService.GetAll();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn { Caption = "Is Selected", DataType = typeof(bool), ColumnName = "IsSelected" });
            dt.Columns.Add(new DataColumn { Caption = "Id", DataType = typeof(int), ColumnName = "Id" });
            dt.Columns.Add(new DataColumn { Caption = "Subject", DataType = typeof(string), ColumnName = "Subject" });
            dt.Columns.Add(new DataColumn { Caption = "Question Count or Percentage", DataType = typeof(int), ColumnName = "QuestionCount" });

            foreach (SubjectDTO subjectDTO in subjectDTOs)
            {
                DataRow row = dt.NewRow();
                row[0] = false;
                row[1] = subjectDTO.Id;
                row[2] = subjectDTO.Name;
                row[3] = 0;

                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            CheckBox box;

            int innitialOffset = 20;
            int xDistance = 200;
            int yDistance = 50;
            int i = 0;
            foreach (var subject in subjectDTOs)
            {
                box = new CheckBox();
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

        public SubjectMultipleSelectionPage(ExamDTO examDTO)
        {
            InitializeComponent();
            FillSubjects();
            this.examDTO = examDTO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxTotalQuestion.Text))
                {
                    MessageBox.Show("number of seconds to answer field cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedSubjects = new List<SubjectDTO>();
                var totalSelectedQuestionCount = 0;
                var totalQuestionCount = int.Parse(textBoxTotalQuestion.Text);
                var dtSource = ((DataTable)dataGridView1.DataSource);

                var list = groupSubjects.Controls.OfType<CheckBox>().Where(c => c.Checked).Select(c => new { c.Text, c.Name, c.Tag }).ToList();
                DataTable dtFiltered = ((DataTable)dataGridView1.DataSource).AsEnumerable()
                                          .Where(row => row.Field<bool>("IsSelected"))
                                          .CopyToDataTable();

                if (dtFiltered != null && dtFiltered.Rows.Count > 0)
                {
                    foreach (DataRow row in dtFiltered.Rows)
                    {
                        selectedSubjects.Add(new SubjectDTO
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Name = row["Subject"].ToString(),
                            QuestionCount = int.Parse(row["QuestionCount"].ToString())
                        });

                        totalSelectedQuestionCount += int.Parse(row["QuestionCount"].ToString());
                    }
                    if(totalSelectedQuestionCount == 100 && totalSelectedQuestionCount!=totalQuestionCount)
                    {
                        selectedSubjects = CalculationHelper.CalculateQuestionCountByPercentage(selectedSubjects, totalQuestionCount);
                        totalSelectedQuestionCount = selectedSubjects.Sum(x => x.QuestionCount);

                        for (int i = 0; i < dtSource.Rows.Count; i++)
                        {
                            if ((bool)dtSource.Rows[i]["IsSelected"])
                            {
                                dtSource.Rows[i]["QuestionCount"] = selectedSubjects.FirstOrDefault(x=>x.Id == int.Parse(dtSource.Rows[i]["Id"].ToString())).QuestionCount;
                            }
                        }

                        dataGridView1.DataSource = dtSource;
                    }
                    examDTO.Subjects = selectedSubjects;
                    examDTO.QuestionCount = totalSelectedQuestionCount;
                }
                else
                {
                    MessageBox.Show("please select any subject(s)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxTotalQuestion.Text))
                {
                    MessageBox.Show("number of seconds to answer field cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var totalQuestionCount = int.Parse(textBoxTotalQuestion.Text);
                var dtSource = ((DataTable)dataGridView1.DataSource);
                selectedSubjects = new List<SubjectDTO>();
                
                DataTable dtFiltered = dtSource.AsEnumerable()
                                          .Where(row => row.Field<bool>("IsSelected"))
                                          .CopyToDataTable();

                if (dtFiltered != null && dtFiltered.Rows.Count > 0)
                {
                    foreach (DataRow row in dtFiltered.Rows)
                    {
                        selectedSubjects.Add(new SubjectDTO
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Name = row["Subject"].ToString(),
                            QuestionCount = int.Parse(row["QuestionCount"].ToString())
                        });
                    }

                    var equalQuestionCount = CalculationHelper.CalculateEqualQuestionCount(selectedSubjects.Count, totalQuestionCount);
                    textBoxTotalQuestion.Text = (equalQuestionCount * selectedSubjects.Count).ToString();
                    examDTO.QuestionCount = equalQuestionCount * selectedSubjects.Count;
                    for (int i=0;i<dtSource.Rows.Count;i++)
                    {
                        if((bool)dtSource.Rows[i]["IsSelected"])
                        {
                            dtSource.Rows[i]["QuestionCount"] = equalQuestionCount;
                        }
                    }

                    dataGridView1.DataSource = dtSource;
                }
                else
                {
                    MessageBox.Show("please select any subject(s)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void textBoxTotalQuestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
