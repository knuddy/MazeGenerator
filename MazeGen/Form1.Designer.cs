namespace MazeGen
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rowInputTextBox = new System.Windows.Forms.TextBox();
            this.collumnInputTextBox = new System.Windows.Forms.TextBox();
            this.collumnCountLabel = new System.Windows.Forms.Label();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.newMazeBtn = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.totalSecondsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.Salmon;
            this.panelCanvas.Location = new System.Drawing.Point(364, 244);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(543, 284);
            this.panelCanvas.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rowInputTextBox
            // 
            this.rowInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowInputTextBox.Location = new System.Drawing.Point(571, 640);
            this.rowInputTextBox.Name = "rowInputTextBox";
            this.rowInputTextBox.Size = new System.Drawing.Size(82, 35);
            this.rowInputTextBox.TabIndex = 1;
            this.rowInputTextBox.Text = "10";
            this.rowInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // collumnInputTextBox
            // 
            this.collumnInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collumnInputTextBox.Location = new System.Drawing.Point(572, 688);
            this.collumnInputTextBox.Name = "collumnInputTextBox";
            this.collumnInputTextBox.Size = new System.Drawing.Size(81, 35);
            this.collumnInputTextBox.TabIndex = 2;
            this.collumnInputTextBox.Text = "50";
            this.collumnInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // collumnCountLabel
            // 
            this.collumnCountLabel.AutoSize = true;
            this.collumnCountLabel.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collumnCountLabel.Location = new System.Drawing.Point(283, 640);
            this.collumnCountLabel.Name = "collumnCountLabel";
            this.collumnCountLabel.Size = new System.Drawing.Size(220, 35);
            this.collumnCountLabel.TabIndex = 3;
            this.collumnCountLabel.Text = "Number of Rows:";
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCountLabel.Location = new System.Drawing.Point(283, 688);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(269, 35);
            this.rowCountLabel.TabIndex = 4;
            this.rowCountLabel.Text = "Number of Collumns:";
            // 
            // newMazeBtn
            // 
            this.newMazeBtn.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMazeBtn.Location = new System.Drawing.Point(689, 640);
            this.newMazeBtn.Name = "newMazeBtn";
            this.newMazeBtn.Size = new System.Drawing.Size(254, 83);
            this.newMazeBtn.TabIndex = 0;
            this.newMazeBtn.Text = "Generate New Maze";
            this.newMazeBtn.UseVisualStyleBackColor = true;
            this.newMazeBtn.Click += new System.EventHandler(this.newMazeBtn_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(195, 13);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(29, 31);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "0";
            // 
            // totalSecondsLabel
            // 
            this.totalSecondsLabel.AutoSize = true;
            this.totalSecondsLabel.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSecondsLabel.Location = new System.Drawing.Point(12, 9);
            this.totalSecondsLabel.Name = "totalSecondsLabel";
            this.totalSecondsLabel.Size = new System.Drawing.Size(189, 35);
            this.totalSecondsLabel.TabIndex = 7;
            this.totalSecondsLabel.Text = "Total Seconds:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.totalSecondsLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.newMazeBtn);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.collumnCountLabel);
            this.Controls.Add(this.collumnInputTextBox);
            this.Controls.Add(this.rowInputTextBox);
            this.Controls.Add(this.panelCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox rowInputTextBox;
        private System.Windows.Forms.TextBox collumnInputTextBox;
        private System.Windows.Forms.Label collumnCountLabel;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button newMazeBtn;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label totalSecondsLabel;
    }
}

