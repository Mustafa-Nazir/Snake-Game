using SnakeGame.Library.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Library.Interface
{
    internal interface IMove
    {

        Size AreaSize { get;}

        int distance { get; }

        /// <summary>
        /// The object is moved
        /// </summary>
        /// <param name="direction">Which direction the object will go</param>
        /// <returns>When the object reach to last of the panel, it will be True </returns>
        bool Move(Direction direction);
    }
}
