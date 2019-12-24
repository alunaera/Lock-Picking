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
            Angle = 0;
            length = 150;
        }

        public void ChangeAngle(int X, int Y)
        {
            if (X - StartPosition.X == 0 || StartPosition.Y - Y == 0)
                Angle = Math.PI / 2;
            else
                Angle = Math.Atan((double)(StartPosition.Y - Y) / (double)(X - StartPosition.X));
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
