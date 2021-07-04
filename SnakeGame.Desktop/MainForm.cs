using SnakeGame.Library.Concrete;
using SnakeGame.Library.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.Desktop
{
    public partial class MainForm : Form
    {
        private readonly Game _game;

        public MainForm()
        {
            InitializeComponent();

            _game = new Game(gameAreaPanel);

            _game.TheTimeCahnge += Game_TheTimeChange;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _game.Start();
                    break;

                case Keys.Up:
                    _game.Move_snake(Direction.Up);
                    break;

                case Keys.Down:
                    _game.Move_snake(Direction.Down);
                    break;

                case Keys.Right:
                    _game.Move_snake(Direction.Right);
                    break;

                case Keys.Left:
                    _game.Move_snake(Direction.Left);
                    break;
            }
        }

        private void Game_TheTimeChange(object sender , EventArgs e)
        {
            timeLabel.Text = _game.TheTime.ToString(@"m\:ss");
        }
    }
}
