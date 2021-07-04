using SnakeGame.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Library.Enum;

namespace SnakeGame.Library.Concrete
{
    class Bait : BaseObject
    {

        public Bait(Size areaSize) : base(areaSize)
        {
            Center = areaSize.Width / 2;
            Middle = areaSize.Height / 2;

            distance = Width;

            ChangeLocation();
           
        }

        private void ChangeLocation()
        {
            Random r = new Random();

            int r1 = r.Next(15);
            int r2 = r.Next(15);

            Direction way1 = r.Next(2) == 0 ? Direction.Down : Direction.Up;
            Direction way2 = r.Next(2) == 0 ? Direction.Right : Direction.Left;

            for(int i = 0; i < r1; i++)
            {
                Move(way1);
            }

            for (int i = 0; i < r2; i++)
            {
                Move(way2);
            }

        }
    }
}
