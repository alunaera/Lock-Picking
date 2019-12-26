using System;
using System.Drawing;

namespace Lock
{
    class Screwdriver
    {
        private int length;

        public readonly Point StartPosition;

        public Point FinishPosition => new Point((int)(length * Math.Cos(Angle)) + StartPosition.X,
            (int)(length * Math.Sin(Angle)) + StartPosition.Y);

        public double Angle { get; private set; }

        public Screwdriver(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            Angle = Math.PI / 2;
            length = 150;
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
