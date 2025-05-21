using System;
using System.Threading.Tasks;


namespace TrickySnake
{
    class GameSettings
    {
        public static int Width {  get; set; }
        public static int Height { get; set; }

        public static string directions;

        public GameSettings()
        {
            Width = 16;
            Heigth = 16;
            directions = "Left";
        }

    }
}
