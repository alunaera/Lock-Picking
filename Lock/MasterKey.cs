using System;
using System.Drawing;

namespace Lock
{
    internal class MasterKey
    {
        private readonly int length;

        private double angle;

        public readonly Point StartPosition;

        public double WinAngle;

        public Point FinishPosition => new Point((int) (length * Math.Cos(angle)) + StartPosition.X,
            (int) (length * Math.Sin(angle)) + StartPosition.Y);

        public MasterKey(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            angle = 0;
            length = 150;
        }

        public void ChangeAngle(int x, int y)
        {
            if (StartPosition.Y - y >= 0)
                angle = StartPosition.X - x >= 0
                    ? Math.Atan((double) (StartPosition.Y - y) / (StartPosition.X - x)) - Math.PI
                    : Math.Atan((double) (StartPosition.Y - y) / (StartPosition.X - x));

            double angleInDegrees = angle * 180 / Math.PI;

        }

        public void SetStartAngle()
        {
            angle = -Math.PI / 2;
        }

        public double GetAngleInDegrees()
        {
            return angle * 180 / Math.PI;
        }
    }
}
