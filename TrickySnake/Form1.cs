using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrickySnake
{
    public partial class Form1 : Form
    {
        private List<Field> snakeBody = new List<Field>();
        private Fruits fruit;
        int maxWidth, maxHeight, scores, highscore, currentSpeed;
        Random rand = new Random();
        private Moving movement;
        private DateTime fspawnTime;
        private Fruits positiveFruit;
        private bool isfirst;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += downKey;
            timer.Tick += timerEvent;
            timer.Interval = 200;
            new GameSettings();
        }
        private void label1_Click(object sender, EventArgs e) { }

        private void downKey(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key pressed: " + e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (movement != Moving.Right) movement = Moving.Left;
                    break;
                case Keys.D:
                    if (movement != Moving.Left) movement = Moving.Right;
                    break;
                case Keys.W:
                    if (movement != Moving.Down) movement = Moving.Up;
                    break;
                case Keys.S:
                    if (movement != Moving.Up) movement = Moving.Down;
                    break;
            }
        }

        private void upKey(object sender, KeyEventArgs e) { }

        private void startGame(object sender, EventArgs e)
        {
            resetGame();
            this.ActiveControl = gameCanvas;
            gameCanvas.Focus();
        }

        private void takeScreenShot(object sender, EventArgs e)
        {
            //label for the text ont the snapshot
            Label capture = new Label();
            capture.Text = "My score : " + scores + " and my record is : " + highscore;
            capture.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            capture.ForeColor = Color.Red;
            capture.AutoSize = false;
            capture.Width = gameCanvas.Width;
            capture.Height = 40;
            capture.TextAlign = ContentAlignment.MiddleCenter;
            gameCanvas.Controls.Add(capture);

            //saving the snapshot
            SaveFileDialog dia = new SaveFileDialog();
            dia.FileName = "TrickySnake images";
            dia.DefaultExt = "jpg";
            dia.Filter = "JPG Image File| *.jpg|PNG Image File|*.png";
            dia.ValidateNames = true;

            if (dia.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(gameCanvas.Width);
                int height = Convert.ToInt32(gameCanvas.Height);
                Bitmap btm = new Bitmap(width, height);
                gameCanvas.DrawToBitmap(btm, new Rectangle(0, 0, width, height));

                string extension = System.IO.Path.GetExtension(dia.FileName).ToLower();

                if (extension == ".png")
                    btm.Save(dia.FileName, ImageFormat.Png);
                else if (extension == ".jpg" || extension == ".jpeg")
                    btm.Save(dia.FileName, ImageFormat.Jpeg);
                else
                    MessageBox.Show("Unkown Fileformat!");
            }
        }
        private void restartGame(object sender, EventArgs e) { resetGame(); }
        private void timerEvent(object sender, EventArgs e)
        {
            int speed = scores / 25;

            Field head = snakeBody[0];
            Field tail = new Field(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y);

            for (int i = snakeBody.Count - 1; i > 0; i--)
            {
                snakeBody[i].X = snakeBody[i - 1].X;
                snakeBody[i].Y = snakeBody[i - 1].Y;
            }
            snakeBody[0].movementManage(movement);

            if (head.X < 0 || head.Y < 0 || head.X > maxWidth || head.Y > maxHeight)
                gameOver();

            if (snakeBody.Skip(1).Any(part => part.Equals(head)))
                gameOver();

            if (head.X == fruit.Position.X && head.Y == fruit.Position.Y)
                snakeEat();
            else if (positiveFruit != null && head.X == positiveFruit.Position.X && head.Y == positiveFruit.Position.Y)
            {
                fruit = positiveFruit;
                snakeEat();
            }

            if (!isfirst && (DateTime.Now - fspawnTime).TotalSeconds >= 20)
            {
                if (snakeBody.Count > 1)
                {
                    snakeBody.RemoveAt(snakeBody.Count - 1);

                    if (scores > 0)
                        scores -= 1; 
                    if (snakeBody.Count == 1 && scores == 0)
                        gameOver();
                }
                else if (snakeBody.Count == 1 && scores == 0)
                    gameOver();
                
                fruit = fruitTypes();
                fspawnTime = DateTime.Now;

                positiveFruit = positiveFruitGen(fruit);
            }
            //speed increase logic
            if (speed > currentSpeed)
            {
                currentSpeed = speed;
                int newInterval = 200 - (currentSpeed * 20);
                if (newInterval <= 40)
                    newInterval = 40;
                timer.Interval = newInterval;
                speedIncrease.Visible = true;
                hideText();
            }

            gameCanvas.Invalidate();
        }
        private async void hideText()
        {
            await Task.Delay(3000);
            speedIncrease.Visible = false;
        }
        private void gameEvent(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; //linking the e paint event to the canvas
            if (fruit?.Position == null)
                return;

            Matrix transf = new Matrix();

            transf.Translate(fruit.Position.X * GameSettings.Width, fruit.Position.Y * GameSettings.Height);
            Brush snake;

            for (int i = 0; i < snakeBody.Count; i++)
            {
                if (i == 0)
                    snake = Brushes.AliceBlue;
                else
                    snake = Brushes.DarkGreen;

                canvas.FillEllipse(snake, new Rectangle(
                        snakeBody[i].X * GameSettings.Width,
                        snakeBody[i].Y * GameSettings.Height,
                        GameSettings.Width, GameSettings.Height
                    ));

            }
            GraphicsPath path = (GraphicsPath)fruit.Shape.Clone();
            path.Transform(transf);
            canvas.FillPath(fruit.Color, path);

            //second positive fruit drawing
            if (positiveFruit != null)
            {
                Matrix positTransf = new Matrix();
                positTransf.Translate(positiveFruit.Position.X * GameSettings.Width, positiveFruit.Position.Y * GameSettings.Height);
                GraphicsPath path2 = (GraphicsPath)positiveFruit.Shape.Clone();
                path2.Transform(positTransf);
                canvas.FillPath(positiveFruit.Color, path2);
            }
        }
        private void snakeEat()
        {
            scores = fruit.ScoreEffect(scores);
            score.Text = "Score: " + scores;
            if (scores == 0)
            {
                gameOver();
            }//the body growth should depend on the fruit's value
            string fruitCount = fruit.Type;
            switch (fruitCount)
            {
                case "Apple":
                    addTail(1);
                    break;
                case "Strawberry":
                    addTail(2);
                    break;
                case "Mango":
                    int length = snakeBody.Count;
                    int add = length == 1 ? 1 : length;
                    addTail(add);
                    break;
                case "Lemon":
                    int snakeLength = snakeBody.Count / 2;
                    snakeBody = snakeBody.Take(snakeLength + 1).ToList();
                    break;
                case "Rock":
                    snakeBody = snakeBody.Take(1).ToList();
                    break;
            }
            fruit = fruitTypes();
            fspawnTime = DateTime.Now;
            isfirst = false;
            positiveFruit = positiveFruitGen(fruit);
        }
        private void gameOver()
        {
            timer.Stop();
            gameStart.Enabled = true;
            gameScreenshot.Enabled = true;
            GameOverrText.Visible = true;

            if (scores > highscore)
            {
                highscore = scores;
                record.Text = "Record : " + highscore;
            }
        }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void resetGame()
        {
            timer.Stop();
            maxWidth = gameCanvas.Width / GameSettings.Width - 1;
            maxHeight = gameCanvas.Height / GameSettings.Height - 1;

            snakeBody.Clear();
            gameStart.Enabled = false;
            gameScreenshot.Enabled = false;
            GameOverrText.Visible = false;
            scores = 0;
            score.Text = "Score : " + scores;

            Field head = new Field(10, 5);
            snakeBody.Add(head);

            fruit = new Fruits("Apple", maxWidth, maxHeight, rand);
            isfirst = true;
            positiveFruit = null;
            movement = Moving.Right;

            currentSpeed = 0;
            timer.Interval = 200;
            timer.Start();
        }
        private Fruits fruitTypes()
        {
            List<string> fruits = new List<string> { "Apple", "Mango", "Strawberry", "Lemon", "Rock" };
            string index = fruits[rand.Next(fruits.Count)];
            fspawnTime = DateTime.Now;
            Fruits mainFruit = new Fruits(index, maxWidth, maxHeight, rand);
            return mainFruit;
        }
        private Fruits positiveFruitGen(Fruits mainFruit)
        {
            //if it generates an "negative" fruit, then it has to generate an "positive" fruit as well

            if (mainFruit.Type == "Rock" || mainFruit.Type == "Lemon")
            {

                List<string> secondFruit = new List<string> { "Apple", "Mango", "Strawberry" };
                Fruits second;
                do
                {
                    string sindex = secondFruit[rand.Next(secondFruit.Count)];
                    second = new Fruits(sindex, maxWidth, maxHeight, rand);
                }
                while (second.Position.X == mainFruit.Position.X && second.Position.Y == mainFruit.Position.Y);
                return second;
            }
            return null;
        }
        private void addTail(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Field last = snakeBody[snakeBody.Count - 1];
                Field newBody = new Field(last.X, last.Y);
                snakeBody.Add(newBody);
            }
        }
    }
}
