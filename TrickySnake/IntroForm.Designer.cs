namespace TrickySnake
{
    partial class IntroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroForm));
            this.gotIt = new System.Windows.Forms.Button();
            this.aboutGame = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gotIt
            // 
            this.gotIt.BackColor = System.Drawing.Color.OliveDrab;
            this.gotIt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gotIt.Location = new System.Drawing.Point(327, 712);
            this.gotIt.Name = "gotIt";
            this.gotIt.Size = new System.Drawing.Size(240, 57);
            this.gotIt.TabIndex = 0;
            this.gotIt.Text = "Got it";
            this.gotIt.UseVisualStyleBackColor = false;
            this.gotIt.Click += new System.EventHandler(this.startTheGame);
            // 
            // aboutGame
            // 
            this.aboutGame.AccessibleDescription = "About the Game";
            this.aboutGame.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.aboutGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutGame.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aboutGame.Location = new System.Drawing.Point(27, 70);
            this.aboutGame.Multiline = true;
            this.aboutGame.Name = "aboutGame";
            this.aboutGame.ReadOnly = true;
            this.aboutGame.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.aboutGame.Size = new System.Drawing.Size(863, 603);
            this.aboutGame.TabIndex = 1;
            this.aboutGame.Text = resources.GetString("aboutGame.Text");
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(902, 808);
            this.Controls.Add(this.aboutGame);
            this.Controls.Add(this.gotIt);
            this.Name = "IntroForm";
            this.Text = "IntroForm";
            this.Load += new System.EventHandler(this.IntroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gotIt;
        private System.Windows.Forms.TextBox aboutGame;
    }
}