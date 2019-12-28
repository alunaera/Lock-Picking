using System;
using System.Drawing;

namespace Lock
{
    internal class Screwdriver
    {
        private readonly int length;

        private double angle;

        public readonly Point StartPosition;

        public Point FinishPosition => new Point((int) (length * Math.Cos(angle)) + StartPosition.X,
            (int) (length * Math.Sin(angle)) + StartPosition.Y);

        public Screwdriver(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            angle = Math.PI / 2;
            length = 150;
        }

        public void RotateStickClockWise()
        {
            angle += Math.PI / 150;
        }

        public void RotateStickCounterClockWise()
        {
            angle -= Math.PI / 125;
        }

        public double GetAngleInRadians()
        {
            return angle;
        }

        public void SetStartAngle()
        {
            angle = Math.PI / 2;
        }
    }
}
