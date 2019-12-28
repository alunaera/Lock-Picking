using System;
using System.Drawing;

namespace Lock
{
    internal class MasterKey
    {
        private readonly int length;

        private double angle;

        public readonly Point StartPosition;

        public MasterKeyPosition Position;
        public double WinAngle;

        public Point FinishPosition => new Point((int) (length * Math.Cos(angle)) + StartPosition.X,
            (int) (length * Math.Sin(angle)) + StartPosition.Y);

        public MasterKey(int startX, int startY)
        {
            StartPosition = new Point(startX, startY);
            angle = 0;
            length = 150;
        }

        public void ChangeAngle(int x, int Y)
        {
            if (StartPosition.Y - Y >= 0)
                angle = StartPosition.X - x >= 0
                    ? Math.Atan((double) (StartPosition.Y - Y) / (StartPosition.X - x)) - Math.PI
                    : Math.Atan((double) (StartPosition.Y - Y) / (StartPosition.X - x));

            double angleInDegrees = angle * 180 / Math.PI;

            if (angleInDegrees < WinAngle + 5 && angleInDegrees > WinAngle - 5)
                Position = MasterKeyPosition.InWinSector;

            if (angleInDegrees > WinAngle + 5 || angleInDegrees < WinAngle - 5)
                Position = MasterKeyPosition.NearWinSector;

            if (angleInDegrees > WinAngle + 30 || angleInDegrees < WinAngle - 30)
                Position = MasterKeyPosition.OutOfWinSector;
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
