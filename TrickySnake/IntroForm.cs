using System;
using System.Windows.Forms;

namespace TrickySnake
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }
        private void IntroForm_Load(object sender, EventArgs e){}

        private void label1_Click(object sender, EventArgs e){ }

        private void startTheGame(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();

            this.Hide();
        }
    }
}
