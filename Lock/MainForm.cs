using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lock
{
    public partial class MainForm : Form
    {

        private readonly Game game = new Game();

        public MainForm()
        {
            InitializeComponent();

            gameField.Paint += Draw;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            game.Draw(e.Graphics);
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            game.ChangeMasterKeyAngle(e.X, e.Y);
            label1.Text = (e.X - 242).ToString();
            label2.Text = (240 - e.Y).ToString();
            label3.Text = (Math.Atan((e.Y - 240) / (e.X - 242))).ToString();
            gameField.Refresh();
        }
    }
}
