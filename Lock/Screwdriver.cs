using System;
using System.Drawing;

namespace Lock
{
    internal class Screwdriver
    {
        private readonly int length;

        public readonly Point StartPosition;

        public double AngleInRadians { get; private set; }

        public Point FinishPosition => new Point((int) (length * Math.Cos(AngleInRadians)) + StartPosition.X,
            (int) (length * Math.Sin(AngleInRadians)) + StartPosition.Y);

        public Screwdriver(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            AngleInRadians = Math.PI / 2;
            length = 150;
        }

        public void RotateClockWise()
        {
            AngleInRadians += Math.PI / 150;
        }

        public void RotateCounterClockWise()
        {
            AngleInRadians -= Math.PI / 125;
        }

        public void SetStartAngle()
        {
            AngleInRadians = Math.PI / 2;
        }
    }
}
