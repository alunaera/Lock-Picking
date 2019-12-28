using System;
using System.Drawing;

namespace Lock
{
    class Game
    {
        private readonly MasterKey masterKey = new MasterKey(CenterX, CenterY - 10);
        private readonly Screwdriver screwdriver = new Screwdriver(CenterX, CenterY + 15);
        private readonly Random random;

        private Pen masterKeyPen;
        private Pen screwdriverPen;

        //It's window's center for correct animation
        private const int CenterX = 242;
        private const int CenterY = 250;

        public GamePhase GamePhase;

        public Game()
        {
            random = new Random();
        }

        public void StartNewRound()
        {
            GamePhase = GamePhase.RotateMasterKey;

            masterKey.WinAngle = GetNewWinAngle();
            masterKeyPen = new Pen(Color.Green, 5);
            screwdriverPen = new Pen(Color.DarkBlue, 5);
        }

        private double GetNewWinAngle()
        {
            return -random.Next(20, 160);
        }

        public void Update(Point cursorPosition)
        {
            switch (GamePhase)
            {
                case GamePhase.RotateMasterKey:
                    RotateMasterKey(cursorPosition.X, cursorPosition.Y);
                    if(screwdriver.GetAngleInRadians() > Math.PI / 2)
                        screwdriver.TiltStickCounterClockWise();
                    break;
                case GamePhase.MoveScrewdriverClockWise:
                    screwdriver.TiltStickClockWise();
                    break;
            }
        }

        private void RotateMasterKey(int positionX, int positionY)
        {
            masterKey.ChangeAngle(positionX, positionY);
        }

        public string GetMasterKeyPosition()
        {
            return masterKey.Position.ToString();
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.Image, 0, 0, 500, 500);

            graphics.FillPie(Brushes.LightGreen, 131, 127, 220, 227,
                (float) (masterKey.WinAngle + 20), -40);
            graphics.FillPie(Brushes.DarkGreen, 131, 127, 220, 227,
                (float)(masterKey.WinAngle + 5), -10);

            graphics.DrawLine(masterKeyPen, masterKey.StartPosition, masterKey.FinishPosition);
            graphics.DrawLine(screwdriverPen, screwdriver.StartPosition, screwdriver.FinishPosition);
        }
    }
}
