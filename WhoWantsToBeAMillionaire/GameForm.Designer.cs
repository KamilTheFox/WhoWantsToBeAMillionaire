namespace WhoWantsToBeAMillionaire
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.RichTextBox();
            this.lstLevel = new System.Windows.Forms.ListBox();
            this.helpersBox = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WhoWantsToBeAMillionaire.Properties.Resources.Миллионером;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-30, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(904, 530);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 41);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 41);
            this.button2.TabIndex = 2;
            this.button2.Tag = "2";
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(223, 583);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 41);
            this.button3.TabIndex = 3;
            this.button3.Tag = "3";
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(223, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 41);
            this.button4.TabIndex = 4;
            this.button4.Tag = "4";
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblQuestion.Location = new System.Drawing.Point(434, 536);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(631, 88);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "";
            // 
            // lstLevel
            // 
            this.lstLevel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLevel.FormattingEnabled = true;
            this.lstLevel.ItemHeight = 31;
            this.lstLevel.Items.AddRange(new object[] {
            "3 000 000",
            "1 500 000",
            "800 000",
            "400 000",
            "200 000",
            "100 000",
            "50 000",
            "25 000",
            "15 000",
            "10 000",
            "5 000",
            "3 000",
            "2 000",
            "1 000",
            "500"});
            this.lstLevel.Location = new System.Drawing.Point(880, 12);
            this.lstLevel.Name = "lstLevel";
            this.lstLevel.Size = new System.Drawing.Size(185, 500);
            this.lstLevel.TabIndex = 6;
            // 
            // helpersBox
            // 
            this.helpersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpersBox.Location = new System.Drawing.Point(1072, 13);
            this.helpersBox.Name = "helpersBox";
            this.helpersBox.Size = new System.Drawing.Size(164, 525);
            this.helpersBox.TabIndex = 7;
            this.helpersBox.TabStop = false;
            this.helpersBox.Text = "Помощь";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(1072, 545);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 79);
            this.button5.TabIndex = 8;
            this.button5.Text = "РЕКОРДЫ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1248, 636);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.helpersBox);
            this.Controls.Add(this.lstLevel);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox lblQuestion;
        private System.Windows.Forms.ListBox lstLevel;
        private System.Windows.Forms.GroupBox helpersBox;
        private System.Windows.Forms.Button button5;
    }
}

