using System;


namespace TrickySnake
{
    internal class Field
    {
        private int x, y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public Field(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Field()
        {
            x = 0;
            y = 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
                return false;
            Field one = (Field)obj;
            return x == one.x && y == one.y;
        }
        public void movementManage(Moving move)
        {
            switch (move)
            {
                case Moving.Left:
                    x--;
                    break;
                case Moving.Right:
                    x++;
                    break;
                case Moving.Up:
                    y--;
                    break;
                case Moving.Down:
                    y++;
                    break;
            }
        }

    }
}
