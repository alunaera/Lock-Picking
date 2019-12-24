using System;
using System.Drawing;

namespace Lock
{
    class MasterKey
    {
        private int length;

        public readonly Point StartPosition;

        public Point FinishPosition => new Point((int)(length * Math.Cos(Angle)) + StartPosition.X,
            (int)(length * Math.Sin(Angle)) + StartPosition.Y);

        public double Angle { get; private set; }

        public MasterKey(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            Angle = -Math.PI / 2;
            length = 150;
        }

        public void ChangeAngle(int X, int Y)
        {
            if (StartPosition.X - X == 0)
                Angle = -Math.PI / 2;
            else
                Angle = Math.Atan(-(StartPosition.Y - Y) / -(StartPosition.X - X)) - Math.PI;
        }

        //public void TiltStickClockWise()
        //{
        //    Angle += Math.PI / 50;
        //}

        //public void TiltStickCounterClockWise()
        //{
        //    Angle -= Math.PI / 50;
        //}
    }
}
