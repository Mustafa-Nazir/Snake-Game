using SnakeGame.Library.Enum;
using SnakeGame.Library.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.Library.Abstract
{
    internal abstract class BaseObject : PictureBox , IMove
    {
        public Size AreaSize { get;}
        public int distance { get; protected set; }

        public int PreviousLeft { get; set; }
        public int PreviousTop { get; set; }


       
        public new int Right
        {
            get => base.Right;
            set => Left = value - Width;

        }

        public new int Bottom
        {
            get => base.Bottom;
            set => Top = value - Height;

        }

        public int Center
        {
            get => (Left + Width) / 2;
            set => Left = value - Width / 2;
        }

        public int Middle
        {
            get => Top + Height / 2;
            set => Top = value - Height / 2;
        }
        protected BaseObject(Size areaSize)
        {
            Image = Image.FromFile(@"image\block.png");

            SizeMode = PictureBoxSizeMode.AutoSize;
            this.AreaSize = areaSize;
        }

        

        public bool Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return MoveToUp();
                case Direction.Down:
                    return MoveToDown();
                case Direction.Right:
                    return MoveToRight();
                case Direction.Left:
                    return MoveToLeft();
                default:
                    return false;
            }
        }

        public void PreviousValue()
        {
            PreviousLeft = Left;
            PreviousTop = Top;
        }

        private bool MoveToLeft()
        {
            if (Left == 0) Left = AreaSize.Width;

            var newLeft = Left - distance;

            Left = newLeft < 0 ? 0 : newLeft;

            return Left == 0;
        }

        private bool MoveToRight()
        {
            if (Right == AreaSize.Width) Right = 0;

            var newRight = Right + distance;
            Right = newRight > AreaSize.Width ? AreaSize.Width : newRight;

            return Right == AreaSize.Width;
        }

        private bool MoveToDown()
        {
            if (Bottom == AreaSize.Height) Bottom = 0;

            var newBottom = Bottom + distance;
            Bottom = newBottom > AreaSize.Height ? AreaSize.Height : newBottom;

            return Bottom == AreaSize.Width;
        }

        private bool MoveToUp()
        {
            if (Top == 0) Top = AreaSize.Height;

            var newTop = Top - distance;

            Top = newTop < 0 ? 0 : newTop;

            return Top == 0;
        }
    }
}
