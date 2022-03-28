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
    public partial class AssignKeysPage : Form
    {
        private AssignKeyService assignKeyService = new AssignKeyService();
        private List<ButtonKeyDTO> buttonKeyDTOs = new List<ButtonKeyDTO>();
        public AssignKeysPage()
        {
            InitializeComponent();
            buttonKeyDTOs = assignKeyService.GetAll();
            dataGridView1.DataSource = buttonKeyDTOs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxNumberOfParticipant.Text))
                {
                    MessageBox.Show("Please enter a number", "Warning");
                    return;
                }
                else if (string.IsNullOrEmpty(textBoxKey.Text))
                {
                    MessageBox.Show("Please enter a number", "Warning");
                    return;
                }
                var subject = assignKeyService.AddButtonKey(new ButtonKeyDTO { Number = int.Parse(textBoxNumberOfParticipant.Text), Key = textBoxKey.Text });

                buttonKeyDTOs = assignKeyService.GetAll();
                dataGridView1.DataSource = buttonKeyDTOs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBoxNumberOfParticipant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.Utility.CheckIsNumericChar(e);
        }
    }
}
