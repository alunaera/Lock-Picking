using System;
using System.Drawing;

namespace Lock
{
    class Game
    {
        private readonly MasterKey masterKey = new MasterKey(CenterX, CenterY - 10);
        private readonly Screwdriver screwdriver = new Screwdriver(CenterX, CenterY + 15);
        private readonly Random random;

        //It's window's center for correct animation
        private const int CenterX = 242;
        private const int CenterY = 250;

        private double winAngle;

        public Game()
        {
            random = new Random();
        }

        public void StartNewRound()
        {
            winAngle = GetNewWinAngle();
        }

        private double GetNewWinAngle()
        {
            return -random.Next(20, 160);
        }

        public void RotateMasterKey(int positionX, int positionY)
        {
            masterKey.ChangeAngle(positionX, positionY);
        }

        public string GetAngle()
        {
            return masterKey.GetAngleInDegrees().ToString();
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.Image, 0, 0, 500, 500);
            graphics.FillPie(Brushes.LightGreen, 131, 127, 220, 227,
                (float) (winAngle + 20), -40);
            graphics.FillPie(Brushes.DarkGreen, 131, 127, 220, 227,
                (float)(winAngle + 5), -10);
            graphics.DrawLine(new Pen(Color.DarkBlue, 5), masterKey.StartPosition, masterKey.FinishPosition);
            graphics.DrawLine(new Pen(Color.DarkRed, 5), screwdriver.StartPosition, screwdriver.FinishPosition);
        }
    }
}
