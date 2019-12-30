using System;
using System.Drawing;

namespace Lock
{
    internal class MasterKey
    {
        private readonly int length;

        private double angleInRadians;

        public readonly Point StartPosition;

        public double WinAngle;

        public double AngleInDegrees => angleInRadians * 180 / Math.PI;
        public Point FinishPosition => new Point((int) (length * Math.Cos(angleInRadians)) + StartPosition.X,
            (int) (length * Math.Sin(angleInRadians)) + StartPosition.Y);

        public MasterKey(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            SetStartAngle();
            length = 150;
        }

        public void ChangeAngle(int x, int y)
        {
            if (StartPosition.Y - y >= 0)
                angleInRadians = StartPosition.X - x >= 0
                    ? Math.Atan((double) (StartPosition.Y - y) / (StartPosition.X - x)) - Math.PI
                    : Math.Atan((double) (StartPosition.Y - y) / (StartPosition.X - x));
        }

        public void SetStartAngle()
        {
            angleInRadians = -Math.PI / 2;
        }
    }
}
