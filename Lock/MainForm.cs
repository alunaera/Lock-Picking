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

            game.StartNewRound();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            game.Draw(e.Graphics);
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            game.RotateMasterKey(e.X, e.Y);
            gameField.Refresh();

            //For development
            label1.Text = (e.X - 242).ToString();
            label2.Text = (240 - e.Y).ToString();
            label3.Text = game.GetAngle();
        }
    }
}
