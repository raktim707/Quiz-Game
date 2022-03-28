namespace QuizApp
{
    partial class SubjectSingleSelectionPage
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
            this.groupSubjects = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuestionCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupSubjects
            // 
            this.groupSubjects.Location = new System.Drawing.Point(65, 12);
            this.groupSubjects.Name = "groupSubjects";
            this.groupSubjects.Size = new System.Drawing.Size(689, 333);
            this.groupSubjects.TabIndex = 0;
            this.groupSubjects.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(362, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(145, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "enter the number of questions";
            // 
            // textBoxQuestionCount
            // 
            this.textBoxQuestionCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxQuestionCount.Location = new System.Drawing.Point(469, 350);
            this.textBoxQuestionCount.Name = "textBoxQuestionCount";
            this.textBoxQuestionCount.Size = new System.Drawing.Size(100, 36);
            this.textBoxQuestionCount.TabIndex = 3;
            this.textBoxQuestionCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuestionCount_KeyPress);
            // 
            // SubjectSingleSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxQuestionCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupSubjects);
            this.Name = "SubjectSingleSelectionPage";
            this.Text = "SubjectSelectionPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupSubjects;
        private Button button1;
        private Label label1;
        private TextBox textBoxQuestionCount;
    }
}