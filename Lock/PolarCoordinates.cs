using System;
using System.Drawing;

namespace Lock
{
    class PolarCoordinates
    {
        private int length;

        public readonly Point StartPosition;

        public Point FinishPosition => new Point((int)(length * Math.Cos(Angle)) + StartPosition.X,
            (int)(length * Math.Sin(Angle)) + StartPosition.Y);

        public double Angle { get; private set; }

        public PolarCoordinates(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            Angle = Math.PI / 2;
            length = 25;
        }

        public void TiltStickClockWise()
        {
            Angle += Math.PI / 50;
        }

        public void TiltStickCounterClockWise()
        {
            Angle -= Math.PI / 50;
        }
    }
}
