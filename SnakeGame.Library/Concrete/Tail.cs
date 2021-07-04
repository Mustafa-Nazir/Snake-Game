using SnakeGame.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Library.Concrete
{
    class Tail : BaseObject
    {


        public Tail(Size areaSize , int left , int top) : base(areaSize)
        {
            Left = left;
            Top = top;
        }

    }
}
