using System;
using System.Drawing;

namespace Lock
{
    internal class Screwdriver
    {
        private int length;
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

        public double GetAngleInRadians()
        {
            return angle;
        }

        public double GetAngleInDegrees()
        {
            return angle * 180 / Math.PI;
        }

        public void TiltStickClockWise()
        {
            angle += Math.PI / 125;
        }

        public void TiltStickCounterClockWise()
        {
            angle -= Math.PI / 125;
        }
    }
}
