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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupSubjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSubjects
            // 
            this.groupSubjects.Controls.Add(this.flowLayoutPanel1);
            this.groupSubjects.Location = new System.Drawing.Point(12, 12);
            this.groupSubjects.Name = "groupSubjects";
            this.groupSubjects.Size = new System.Drawing.Size(776, 330);
            this.groupSubjects.TabIndex = 1;
            this.groupSubjects.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 308);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(284, 366);
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
            this.groupSubjects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupSubjects;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}