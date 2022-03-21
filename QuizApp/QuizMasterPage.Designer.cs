namespace QuizApp
{
    partial class QuizMasterPage
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
            this.SuspendLayout();
            // 
            // groupSubjects
            // 
            this.groupSubjects.Location = new System.Drawing.Point(12, 12);
            this.groupSubjects.Name = "groupSubjects";
            this.groupSubjects.Size = new System.Drawing.Size(539, 333);
            this.groupSubjects.TabIndex = 1;
            this.groupSubjects.TabStop = false;
            this.groupSubjects.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(214, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "SELECT && ASK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuizMasterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupSubjects);
            this.KeyPreview = true;
            this.Name = "QuizMasterPage";
            this.Text = "QuizMasterPage";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuizMasterPage_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupSubjects;
        private Button button1;
    }
}