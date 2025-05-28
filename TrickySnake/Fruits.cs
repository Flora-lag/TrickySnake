using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickySnake
{//5 types of friuts:apple+1,mango*2,lemon?/2,strawberry+2,rock-game over
    internal class Fruits
    {

        public string Type { get; set; }
      
        public GraphicsPath Shape { get; set; }
        public Field Position { get; set; }

        public Brush Color { get; set; }

        public Fruits(string type,int maxWidth,int maxHeight,Random rand)
        {   
            Type = type;
            Shape =new GraphicsPath(); 
            Color= CreateShape();
            Position=RandomPosition(maxWidth, maxHeight,rand);

            
        }
        private Field RandomPosition(int maxWidth, int maxHeight, Random rand)
        {
            if (maxWidth <= 2 || maxHeight <= 2)
                return new Field(5, 5);

            return new Field(rand.Next(1, maxWidth), rand.Next(1, maxHeight));
        }
        private Brush CreateShape()
        {//for the even sizes
            int w=GameSettings.Width;
            int h=GameSettings.Height;
            
            switch (Type)
            {
                case "Apple":
                    Shape.AddEllipse(0, 0, w, h);
                    return Brushes.DarkRed;
                case "Mango":
                    Shape.AddBezier(new Point(0, h/2), new Point(w/2, h), new Point(w-5, h), new Point(w, h/2));
                    return Brushes.DarkGoldenrod;

                case "Strawberry":
                    Point[] triangle = { new Point(w/2, 0), new Point(0, h), new Point(w, h) };
                    Shape.AddPolygon(triangle);
                    return Brushes.DarkSalmon;

                case "Lemon":
                    Shape.AddEllipse(w/4, 0, w*3/4, h/2);
                    return Brushes.LemonChiffon;

                case "Rock":
                    Shape.AddRectangle(new Rectangle(0, 0, w, h));
                    return Brushes.SteelBlue;

                default:
                    return Brushes.LightGray;
            }
           
        }
        public int ScoreEffect(int score)
        {
            switch (Type)
            {
                case "Apple":
                    return score + 1;
                case "Strawberry":
                    return score + 2;
                case "Mango":
                    return score * 2;
                case "Lemon":
                    return score / 2;
                case "Rock":
                    return 0;
                default:
                    return score;
                

            }
        }
    }
}
