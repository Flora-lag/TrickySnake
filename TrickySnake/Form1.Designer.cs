namespace TrickySnake
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
            this.gameStart = new System.Windows.Forms.Button();
            this.gameScreenshot = new System.Windows.Forms.Button();
            this.gameRestart = new System.Windows.Forms.Button();
            this.gameCanvas = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            this.record = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // gameStart
            // 
            this.gameStart.AccessibleDescription = "Start the game button";
            this.gameStart.BackColor = System.Drawing.Color.OliveDrab;
            this.gameStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStart.Location = new System.Drawing.Point(75, 732);
            this.gameStart.Name = "gameStart";
            this.gameStart.Size = new System.Drawing.Size(181, 64);
            this.gameStart.TabIndex = 0;
            this.gameStart.Text = "Start the Game";
            this.gameStart.UseVisualStyleBackColor = false;
            this.gameStart.Click += new System.EventHandler(this.startGame);
            // 
            // gameScreenshot
            // 
            this.gameScreenshot.AccessibleDescription = "Screenshot button";
            this.gameScreenshot.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gameScreenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameScreenshot.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameScreenshot.Location = new System.Drawing.Point(343, 732);
            this.gameScreenshot.Name = "gameScreenshot";
            this.gameScreenshot.Size = new System.Drawing.Size(181, 64);
            this.gameScreenshot.TabIndex = 1;
            this.gameScreenshot.Text = "Screenshot";
            this.gameScreenshot.UseVisualStyleBackColor = false;
            this.gameScreenshot.Click += new System.EventHandler(this.takeScreenShot);
            // 
            // gameRestart
            // 
            this.gameRestart.AccessibleDescription = "Restart the game button";
            this.gameRestart.BackColor = System.Drawing.Color.Tomato;
            this.gameRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameRestart.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameRestart.Location = new System.Drawing.Point(596, 732);
            this.gameRestart.Name = "gameRestart";
            this.gameRestart.Size = new System.Drawing.Size(181, 64);
            this.gameRestart.TabIndex = 2;
            this.gameRestart.Text = "Restart";
            this.gameRestart.UseVisualStyleBackColor = false;
            this.gameRestart.Click += new System.EventHandler(this.restartGame);
            // 
            // gameCanvas
            // 
            this.gameCanvas.AccessibleDescription = "Canvas for the Game";
            this.gameCanvas.BackColor = System.Drawing.Color.SeaGreen;
            this.gameCanvas.Location = new System.Drawing.Point(50, 43);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(795, 581);
            this.gameCanvas.TabIndex = 3;
            this.gameCanvas.TabStop = false;
            this.gameCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.gameEvent);
            // 
            // score
            // 
            this.score.AccessibleDescription = "Score";
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score.Location = new System.Drawing.Point(204, 665);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(88, 30);
            this.score.TabIndex = 4;
            this.score.Text = "Score :";
            this.score.Click += new System.EventHandler(this.label1_Click);
            // 
            // record
            // 
            this.record.AccessibleDescription = "Score";
            this.record.AutoSize = true;
            this.record.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.record.Location = new System.Drawing.Point(488, 665);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(112, 30);
            this.record.TabIndex = 5;
            this.record.Text = "Record : ";
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 808);
            this.Controls.Add(this.record);
            this.Controls.Add(this.score);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.gameRestart);
            this.Controls.Add(this.gameScreenshot);
            this.Controls.Add(this.gameStart);
            this.Name = "Form1";
            this.Text = "TrickySnake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.downKey);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.upKey);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gameStart;
        private System.Windows.Forms.Button gameScreenshot;
        private System.Windows.Forms.Button gameRestart;
        private System.Windows.Forms.PictureBox gameCanvas;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label record;
        private System.Windows.Forms.Timer timer;
    }
}

