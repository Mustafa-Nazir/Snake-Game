using SnakeGame.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Library.Interface
{
    internal interface IGame
    {
        event EventHandler TheTimeCahnge;

        bool isOpen { get; }

        TimeSpan TheTime { get; }

        void Start();

        void Move_snake(Direction direction);
    }
}
