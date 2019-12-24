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
            if (StartPosition.Y - Y >= 0)
                Angle = StartPosition.X - X >= 0 
                    ? Math.Atan((double)(StartPosition.Y - Y) / (StartPosition.X - X)) + Math.PI 
                    : Math.Atan((double)(StartPosition.Y - Y) / (StartPosition.X - X));
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
