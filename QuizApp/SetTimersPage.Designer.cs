namespace QuizApp
{
    partial class SetTimersPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxNoSAnswer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNoSPressButton = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBoxNoSAnswer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNoSPressButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(250, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "SUBMIT && Start Game ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxNoSAnswer
            // 
            this.textBoxNoSAnswer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNoSAnswer.Location = new System.Drawing.Point(464, 86);
            this.textBoxNoSAnswer.Name = "textBoxNoSAnswer";
            this.textBoxNoSAnswer.Size = new System.Drawing.Size(170, 36);
            this.textBoxNoSAnswer.TabIndex = 3;
            this.textBoxNoSAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNoSAnswer_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(464, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "number of seconds answer";
            // 
            // textBoxNoSPressButton
            // 
            this.textBoxNoSPressButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNoSPressButton.Location = new System.Drawing.Point(68, 86);
            this.textBoxNoSPressButton.Name = "textBoxNoSPressButton";
            this.textBoxNoSPressButton.Size = new System.Drawing.Size(170, 36);
            this.textBoxNoSPressButton.TabIndex = 1;
            this.textBoxNoSPressButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNoSPressButton_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(68, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "number of seconds to press button";
            // 
            // SetTimersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetTimersPage";
            this.Text = "SetTimersPage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBoxNoSAnswer;
        private Label label2;
        private TextBox textBoxNoSPressButton;
        private Label label1;
    }
}