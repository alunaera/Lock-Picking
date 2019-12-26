﻿using System;
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

        public void ChangeAngle(int x, int Y)
        {
            if (StartPosition.Y - Y >= 0)
                Angle = StartPosition.X - x >= 0 
                    ? Math.Atan((double)(StartPosition.Y - Y) / (StartPosition.X - x)) - Math.PI 
                    : Math.Atan((double)(StartPosition.Y - Y) / (StartPosition.X - x));
        }
    }
}
