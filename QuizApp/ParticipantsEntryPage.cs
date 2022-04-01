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
    public partial class ParticipantsEntryPage : Form
    {
        private ExamDTO examDTO;
        private ParticipantService participantService = new ParticipantService();

        public ParticipantsEntryPage()
        {
            InitializeComponent();
        }

        public ParticipantsEntryPage(ExamDTO examDTO)
        {
            this.examDTO = examDTO;
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn { Caption = "Participant Name", ColumnName = "ParticipantName" });
            dt.Columns.Add(new DataColumn { Caption = "Button", ColumnName = "Button" });

            for (int j = 0; j < examDTO.ParticipantCount; j++)
            {
                DataRow row = dt.NewRow();
                
                dt.Rows.Add(row);
            }
            dataGridViewParticipants.DataSource = dt;
        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //TODO focus again cell
            var gridView = (DataGridView)sender;
            var cell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell == null)
            {
                MessageBox.Show("please enter a value", "Warning");
                //dataGridView1.BeginEdit(true);//dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewParticipants.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                dataGridViewParticipants.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            else if (e.ColumnIndex == 1 && !cell.Value.ToString().IsNumeric())
            {
                MessageBox.Show("please enter a numeric value", "Warning");
                //dataGridView1.BeginEdit(true);//return;
                dataGridViewParticipants.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                dataGridViewParticipants.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParticipantDTO> participants = new List<ParticipantDTO>();
                int participantCount = 0;
                foreach (DataRow dr in ((DataTable)dataGridViewParticipants.DataSource).Rows)
                {
                    if (!string.IsNullOrEmpty(dr.Field<string>("ParticipantName")) && !string.IsNullOrEmpty(dr.Field<string>("Button")))
                    {
                        var participant =
                          new ParticipantDTO
                          {
                              ExamId = examDTO.Id,
                              Name = dr.Field<string>("ParticipantName"),
                              ButtonNumber = int.Parse(dr.Field<string>("Button"))
                          };

                        participantService.AddParticipant(participant);
                        participantCount++;
                    }
                }
                if (participantCount < examDTO.ParticipantCount)
                    examDTO.ParticipantCount = participantCount;

                this.Hide();
                Form form = new SubjectCountSelectionPage(examDTO);
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridViewParticipants_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumeric_KeyPress);
            if (dataGridViewParticipants.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnNumeric_KeyPress);
                }
            }
        }

        private void ColumnNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
