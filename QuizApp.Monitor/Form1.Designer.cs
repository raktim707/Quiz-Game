namespace QuizApp.Monitor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelId = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxAnswer = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelAnsweredParticipant = new System.Windows.Forms.Label();
            this.labelCountdownToAnswer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCountdownToPress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNumberofQuestions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNumberOfParticipants = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxQuestion = new System.Windows.Forms.GroupBox();
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTopScorer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxAnswer.SuspendLayout();
            this.groupBoxQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelSubject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBoxQuestion);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 445);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(393, 14);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(38, 15);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "label5";
            this.labelId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTopScorer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBoxAnswer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelCountdownToPress);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelNumberofQuestions);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelNumberOfParticipants);
            this.groupBox2.Location = new System.Drawing.Point(523, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 421);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBoxAnswer
            // 
            this.groupBoxAnswer.Controls.Add(this.label6);
            this.groupBoxAnswer.Controls.Add(this.label7);
            this.groupBoxAnswer.Controls.Add(this.labelAnsweredParticipant);
            this.groupBoxAnswer.Controls.Add(this.labelCountdownToAnswer);
            this.groupBoxAnswer.Enabled = false;
            this.groupBoxAnswer.Location = new System.Drawing.Point(6, 222);
            this.groupBoxAnswer.Name = "groupBoxAnswer";
            this.groupBoxAnswer.Size = new System.Drawing.Size(257, 134);
            this.groupBoxAnswer.TabIndex = 13;
            this.groupBoxAnswer.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 19);
            this.label6.MaximumSize = new System.Drawing.Size(120, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 30);
            this.label6.TabIndex = 9;
            this.label6.Text = "Participant who First Pressed The Button";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.MaximumSize = new System.Drawing.Size(120, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 30);
            this.label7.TabIndex = 11;
            this.label7.Text = "Countdown to Answer";
            // 
            // labelAnsweredParticipant
            // 
            this.labelAnsweredParticipant.AutoSize = true;
            this.labelAnsweredParticipant.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelAnsweredParticipant.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAnsweredParticipant.Location = new System.Drawing.Point(141, 19);
            this.labelAnsweredParticipant.Name = "labelAnsweredParticipant";
            this.labelAnsweredParticipant.Size = new System.Drawing.Size(0, 30);
            this.labelAnsweredParticipant.TabIndex = 10;
            // 
            // labelCountdownToAnswer
            // 
            this.labelCountdownToAnswer.AutoSize = true;
            this.labelCountdownToAnswer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCountdownToAnswer.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCountdownToAnswer.Location = new System.Drawing.Point(141, 55);
            this.labelCountdownToAnswer.Name = "labelCountdownToAnswer";
            this.labelCountdownToAnswer.Size = new System.Drawing.Size(48, 59);
            this.labelCountdownToAnswer.TabIndex = 12;
            this.labelCountdownToAnswer.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 173);
            this.label4.MaximumSize = new System.Drawing.Size(120, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Countdown to Press Button";
            // 
            // labelCountdownToPress
            // 
            this.labelCountdownToPress.AutoSize = true;
            this.labelCountdownToPress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCountdownToPress.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCountdownToPress.Location = new System.Drawing.Point(142, 149);
            this.labelCountdownToPress.Name = "labelCountdownToPress";
            this.labelCountdownToPress.Size = new System.Drawing.Size(48, 59);
            this.labelCountdownToPress.TabIndex = 8;
            this.labelCountdownToPress.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Questions";
            // 
            // labelNumberofQuestions
            // 
            this.labelNumberofQuestions.AutoSize = true;
            this.labelNumberofQuestions.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelNumberofQuestions.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberofQuestions.Location = new System.Drawing.Point(142, 83);
            this.labelNumberofQuestions.Name = "labelNumberofQuestions";
            this.labelNumberofQuestions.Size = new System.Drawing.Size(88, 59);
            this.labelNumberofQuestions.TabIndex = 6;
            this.labelNumberofQuestions.Text = "0/0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Participants";
            // 
            // labelNumberOfParticipants
            // 
            this.labelNumberOfParticipants.AutoSize = true;
            this.labelNumberOfParticipants.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelNumberOfParticipants.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberOfParticipants.Location = new System.Drawing.Point(142, 17);
            this.labelNumberOfParticipants.Name = "labelNumberOfParticipants";
            this.labelNumberOfParticipants.Size = new System.Drawing.Size(48, 59);
            this.labelNumberOfParticipants.TabIndex = 4;
            this.labelNumberOfParticipants.Text = "0";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSubject.Location = new System.Drawing.Point(117, 10);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(0, 30);
            this.labelSubject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject: ";
            // 
            // groupBoxQuestion
            // 
            this.groupBoxQuestion.Controls.Add(this.labelOptions);
            this.groupBoxQuestion.Controls.Add(this.labelQuestion);
            this.groupBoxQuestion.Location = new System.Drawing.Point(7, 36);
            this.groupBoxQuestion.Name = "groupBoxQuestion";
            this.groupBoxQuestion.Size = new System.Drawing.Size(510, 403);
            this.groupBoxQuestion.TabIndex = 0;
            this.groupBoxQuestion.TabStop = false;
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOptions.Location = new System.Drawing.Point(9, 178);
            this.labelOptions.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(89, 30);
            this.labelOptions.TabIndex = 1;
            this.labelOptions.Text = "Options";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuestion.Location = new System.Drawing.Point(9, 21);
            this.labelQuestion.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(100, 30);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Question";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 359);
            this.label5.MaximumSize = new System.Drawing.Size(120, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Top Scorer";
            // 
            // labelTopScorer
            // 
            this.labelTopScorer.AutoSize = true;
            this.labelTopScorer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelTopScorer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTopScorer.Location = new System.Drawing.Point(147, 359);
            this.labelTopScorer.Name = "labelTopScorer";
            this.labelTopScorer.Size = new System.Drawing.Size(0, 30);
            this.labelTopScorer.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxAnswer.ResumeLayout(false);
            this.groupBoxAnswer.PerformLayout();
            this.groupBoxQuestion.ResumeLayout(false);
            this.groupBoxQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label labelSubject;
        private Label label1;
        private GroupBox groupBoxQuestion;
        private Label labelOptions;
        private Label labelQuestion;
        private GroupBox groupBox2;
        private Label label7;
        private Label labelCountdownToAnswer;
        private Label label6;
        private Label labelAnsweredParticipant;
        private Label label4;
        private Label labelCountdownToPress;
        private Label label3;
        private Label labelNumberofQuestions;
        private Label label2;
        private Label labelNumberOfParticipants;
        private GroupBox groupBoxAnswer;
        private Label labelId;
        private Label labelTopScorer;
        private Label label5;
    }
}