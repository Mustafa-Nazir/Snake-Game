using SnakeGame.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Library.Concrete
{
    class Snake : BaseObject
    {
        public Snake(Size areaSize) : base(areaSize)
        {

            Center = areaSize.Width / 2;
            Middle = areaSize.Height / 2;

            distance = Width;
        }
    }
}
