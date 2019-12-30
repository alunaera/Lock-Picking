using System;
using System.Drawing;

namespace Lock
{
    internal class Game
    {
        private readonly MasterKey masterKey = new MasterKey(CenterX, CenterY - 10);
        private readonly Screwdriver screwdriver = new Screwdriver(CenterX, CenterY + 15);
        private readonly Font font = new Font("Arial", 12);
        private readonly Pen masterKeyPen;
        private readonly Pen screwdriverPen;
        private readonly Random random;

        private MasterKeyPosition masterKeyPosition;
        private GamePhase gamePhase;
        private int masterKeyStrength;
        private int brokenMasterKeysCount;
        private int openedLocksCount;

        //It's window's center for correct animation
        private const int CenterX = 242;
        private const int CenterY = 250;

        public Game()
        {
            random = new Random();

            masterKeyPen = new Pen(Color.Green, 5);
            screwdriverPen = new Pen(Color.DarkBlue, 5);
        }

        public void StartNewGame()
        {
            brokenMasterKeysCount = 0;
            openedLocksCount = 0;

            CreateNewWinAngle();
            CreateNewMasterKey();
        }

        private void CreateNewMasterKey()
        {
            masterKeyPen.Color = Color.Green;
            masterKey.SetStartAngle();
            masterKeyStrength = 100;

            screwdriver.SetStartAngle();
        }

        private void CreateNewWinAngle()
        {
            masterKeyPen.Color = Color.Green;
            masterKey.SetStartAngle();
            masterKey.WinAngle = -random.Next(20, 160);

            screwdriver.SetStartAngle();
        }

        public void RotateMasterKey(int positionX, int positionY)
        {
            if (gamePhase == GamePhase.RotateMasterKey)
                masterKey.ChangeAngle(positionX, positionY);
        }

        public void Update()
        {
            switch (gamePhase)
            {
                case GamePhase.RotateMasterKey:
                    RotateMasterKey();
                    break;
                case GamePhase.MoveScrewdriver:
                    MoveScrewdriver();
                    break;
            }
        }

        private void RotateMasterKey()
        {
            masterKeyPen.Color = Color.Green;

            if (screwdriver.AngleInRadians > Math.PI / 2)
                screwdriver.RotateCounterClockWise();
        }

        private void MoveScrewdriver()
        {
            switch (masterKeyPosition)
            {
                case MasterKeyPosition.OutOfWinSector:
                    masterKeyPen.Color = Color.Red;
                    masterKeyStrength--;

                    if (masterKeyStrength == 0)
                    {
                        brokenMasterKeysCount++;
                        CreateNewMasterKey();
                    }

                    break;

                case MasterKeyPosition.NearWinSector:
                    double screwdriverMaxAngle =
                        Math.PI * (1 - (Math.Abs(masterKey.AngleInDegrees - masterKey.WinAngle) - 5) / 60);

                    if (screwdriver.AngleInRadians < screwdriverMaxAngle)
                        screwdriver.RotateClockWise();

                    if (screwdriver.AngleInRadians >= screwdriverMaxAngle)
                    {
                        masterKeyPen.Color = Color.Red;
                        masterKeyStrength--;

                        if (masterKeyStrength == 0)
                        {
                            brokenMasterKeysCount++;
                            CreateNewMasterKey();
                        }
                    }

                    break;

                case MasterKeyPosition.InWinSector:
                    if (screwdriver.AngleInRadians < Math.PI)
                        screwdriver.RotateClockWise();

                    if (screwdriver.AngleInRadians >= Math.PI)
                    {
                        openedLocksCount++;
                        CreateNewWinAngle();
                    }

                    break;
            }

            double masterKeyDeviationFromWinAngle = Math.Abs(masterKey.AngleInDegrees - masterKey.WinAngle);

            if (masterKeyDeviationFromWinAngle <= 5)
                masterKeyPosition = MasterKeyPosition.InWinSector;
            else if (masterKeyDeviationFromWinAngle < 30)
                masterKeyPosition = MasterKeyPosition.NearWinSector;
            else
                masterKeyPosition = MasterKeyPosition.OutOfWinSector;
        }

        public void StartLocking()
        {
            gamePhase = GamePhase.MoveScrewdriver;
        }

        public void StopLocking()
        {
            gamePhase = GamePhase.RotateMasterKey;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.Image, 0, 0, 500, 500);

            graphics.DrawLine(masterKeyPen, masterKey.StartPosition, masterKey.FinishPosition);
            graphics.DrawLine(screwdriverPen, screwdriver.StartPosition, screwdriver.FinishPosition);

            graphics.DrawString("Broken master keys: " + brokenMasterKeysCount, font, Brushes.Black, 285, 30);
            graphics.DrawString("Opened locks: " + openedLocksCount, font, Brushes.Black, 285, 50);
        }
    }
}
