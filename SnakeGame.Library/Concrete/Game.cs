using SnakeGame.Library.Abstract;
using SnakeGame.Library.Enum;
using SnakeGame.Library.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.Library.Concrete
{
    public class Game : IGame
    {

        #region Fields

        private Timer _theTimeTimer = new Timer { Interval = 1000 };
        private Timer _MoveTimer = new Timer { Interval = 100 };
        private TimeSpan _theTime;

        private readonly Panel _snakePanel;

        private Snake _Snake;
        private Bait _Bait;

        private List<BaseObject> Snakes = new List<BaseObject>();

        Direction direction = Direction.Up;

        #endregion

        public event EventHandler TheTimeCahnge;

        #region Properties
        public bool isOpen { get; private set; }

        public TimeSpan TheTime 
        {
            get => _theTime;
            private set 
            { 
                _theTime = value;

                TheTimeCahnge?.Invoke(this, EventArgs.Empty);
            } 
        }
        #endregion  


        public Game(Panel snakePanel)
        {
            this._snakePanel = snakePanel;

            _theTimeTimer.Tick += TheTimeTimer_Tick;
            _MoveTimer.Tick += MoveTimer_Tick;

            _Bait = new Bait(this._snakePanel.Size);
            this._snakePanel.Controls.Add(_Bait);
        }

        private void MoveTimer_Tick(object sender , EventArgs e)
        {
            for (int i = 0; i < Snakes.Count; i++)
            {
                if(i == 0)
                {
                    Snakes[i].PreviousValue();
                    Snakes[i].Move(this.direction);
                    IsEnd();
                    CheckBait();
                    continue;
                }

                Snakes[i].PreviousValue();
                Snakes[i].Top = Snakes[i - 1].PreviousTop;
                Snakes[i].Left = Snakes[i - 1].PreviousLeft;
            }

        }

        #region Methods

        private void IsEnd()
        {
            for(int i = 0; i < Snakes.Count; i++)
            {
                if (i == 0) continue;

                if (Math.Abs(_Snake.Top - Snakes[i].Top) <= _Snake.Height / 2 && Math.Abs(_Snake.Left - Snakes[i].Left) <= _Snake.Width / 2) End();
            }
        }


        private void CheckBait()
        {
            if(Math.Abs(_Snake.Top - _Bait.Top) <= _Snake.Height / 2 && Math.Abs(_Snake.Left - _Bait.Left) <= _Snake.Width / 2)
            {
                _snakePanel.Controls.Remove(_Bait);
                CreatTail();

                _Bait = new Bait(_snakePanel.Size);
                _snakePanel.Controls.Add(_Bait);
            }
        }

        private void CreatTail()
        {

            Tail tail = new Tail(_snakePanel.Size, Snakes[Snakes.Count - 1].PreviousTop, Snakes[Snakes.Count - 1].PreviousLeft);

            Snakes.Add(tail);

            _snakePanel.Controls.Add(tail);
        }


        private void TheTimeTimer_Tick(object sender , EventArgs e)
        {
            TheTime += TimeSpan.FromSeconds(1);
        }

        public void Move_snake(Direction direction)
        {
            if (!isOpen) return;

            if((this.direction == Direction.Up || this.direction == Direction.Down) && (direction == Direction.Left || direction == Direction.Right))
            {
                this.direction = direction;
            }
            else if ((this.direction == Direction.Right || this.direction == Direction.Left) && (direction == Direction.Up || direction == Direction.Down))
            {
                this.direction = direction;
            }

        }

        public void Start()
        {
            if (isOpen) return;

            isOpen = true;
            _theTimeTimer.Start();

            CreateSnake();

            _MoveTimer.Start();
        }

        private void End()
        {
            if (!isOpen) return;

            isOpen = false;
            _theTimeTimer.Stop();
            _MoveTimer.Stop();

            Application.Restart();

        }

        private void CreateSnake()
        {
            _Snake = new Snake(_snakePanel.Size);
            _snakePanel.Controls.Add(_Snake);
            Snakes.Add(_Snake);
            
        }
        #endregion  
    }
}
