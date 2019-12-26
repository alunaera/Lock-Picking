using System.Drawing;

namespace Lock
{
    class Game
    {
        MasterKey masterKey = new MasterKey(242, 240);
        Screwdriver screwdriver = new Screwdriver(242, 265);

        public void ChangeMasterKeyAngle(int positionX, int positionY)
        {
            masterKey.ChangeAngle(positionX, positionY);
        }

        public string GetAngle()
        {
            return masterKey.Angle.ToString();
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.Image, 0, 0, 500, 500);
            graphics.DrawLine(new Pen(Color.DarkBlue, 5), masterKey.StartPosition, masterKey.FinishPosition);
            graphics.DrawLine(new Pen(Color.DarkGreen, 5), screwdriver.StartPosition, screwdriver.FinishPosition);
        }
    }
}
