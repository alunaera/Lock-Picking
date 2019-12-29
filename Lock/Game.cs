using System;
using System.Drawing;

namespace Lock
{
    internal class Game
    {
        private readonly MasterKey masterKey = new MasterKey(CenterX, CenterY - 10);
        private readonly Screwdriver screwdriver = new Screwdriver(CenterX, CenterY + 15);
        private readonly Font font = new Font("Arial", 12);
        private readonly Random random;

        private Pen masterKeyPen;
        private Pen screwdriverPen;
        private MasterKeyPosition masterKeyPosition;
        private int masterKeyStrength;
        private int brokenMasterKeysCount;
        private int openedLocksCount;

        //It's window's center for correct animation
        private const int CenterX = 242;
        private const int CenterY = 250;

        public Point CursorPosition { private get; set; }
        public GamePhase GamePhase;

        public Game()
        {
            random = new Random();
        }

        public void StartNewGame()
        {
            GamePhase = GamePhase.RotateMasterKey;

            brokenMasterKeysCount = 0;
            openedLocksCount = 0;

            masterKey.WinAngle = GetNewWinAngle();
            masterKeyPen = new Pen(Color.Green, 5);
            masterKeyStrength = 70;

            screwdriver.SetStartAngle();
            screwdriverPen = new Pen(Color.DarkBlue, 5);
        }

        private void CreateNewMasterKey()
        {
            GamePhase = GamePhase.RotateMasterKey;

            masterKeyPen.Color = Color.Green;
            masterKey.SetStartAngle();
            masterKeyStrength = 70;

            screwdriver.SetStartAngle();
        }

        private void CreateNewWinAngle()
        {
            GamePhase = GamePhase.RotateMasterKey;

            masterKey.WinAngle = GetNewWinAngle();
            masterKeyPen.Color = Color.Green;
            masterKey.SetStartAngle();

            screwdriver.SetStartAngle();
        }

        private double GetNewWinAngle()
        {
            return -random.Next(20, 160);
        }

        public void Update()
        {
            SetMasterKeyPosition();

            switch (GamePhase)
            {
                case GamePhase.RotateMasterKey:
                    RotateMasterKey();
                    break;
                case GamePhase.MoveScrewdriverClockWise:
                    MoveScrewdriverClockWise();
                    break;
            }
        }

        private void RotateMasterKey()
        {
            masterKeyPen.Color = Color.Green;
            masterKey.ChangeAngle(CursorPosition.X, CursorPosition.Y);

            if (screwdriver.GetAngleInRadians() > Math.PI / 2)
                screwdriver.RotateStickCounterClockWise();
        }

        private void MoveScrewdriverClockWise()
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
                        Math.PI * (1 - (Math.Abs(masterKey.WinAngle - masterKey.GetAngleInDegrees()) - 5) / 60);

                    if (screwdriver.GetAngleInRadians() < screwdriverMaxAngle)
                        screwdriver.RotateStickClockWise();

                    if (screwdriver.GetAngleInRadians() >= screwdriverMaxAngle)
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
                    if (screwdriver.GetAngleInRadians() < Math.PI)
                        screwdriver.RotateStickClockWise();

                    if (screwdriver.GetAngleInRadians() >= Math.PI)
                    {
                        openedLocksCount++;
                        CreateNewWinAngle();
                    }

                    break;
            }
        }

        private void SetMasterKeyPosition()
        {
            if (masterKey.GetAngleInDegrees() < masterKey.WinAngle + 5 &&
                masterKey.GetAngleInDegrees() > masterKey.WinAngle - 5)
                masterKeyPosition = MasterKeyPosition.InWinSector;

            if (masterKey.GetAngleInDegrees() > masterKey.WinAngle + 5 ||
                masterKey.GetAngleInDegrees() < masterKey.WinAngle - 5)
                masterKeyPosition = MasterKeyPosition.NearWinSector;

            if (masterKey.GetAngleInDegrees() > masterKey.WinAngle + 30 ||
                masterKey.GetAngleInDegrees() < masterKey.WinAngle - 30)
                masterKeyPosition = MasterKeyPosition.OutOfWinSector;
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
