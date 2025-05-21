using System;
using System.Threading.Tasks;


namespace TrickySnake
{
    class GameSettings
    {
        public static int Width {  get; set; }
        public static int Height { get; set; }

       

        public GameSettings()
        {
            Width = 24;
            Height = 24;
           
        }

    }
}
