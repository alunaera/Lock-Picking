using System;
using System.Drawing;

namespace Lock
{
    class Game
    {
        MasterKey masterKey = new MasterKey(242, 240);

        public void ChangeMasterKeyAngle(int positionX, int positionY)
        {
            masterKey.ChangeAngle(positionX, positionY);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.Image, 0, 0, 500, 500);
            graphics.DrawLine(new Pen(Color.Black, 5), masterKey.StartPosition, masterKey.FinishPosition);
        }
    }
}
