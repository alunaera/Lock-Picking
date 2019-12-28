using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lock
{
    public partial class MainForm : Form
    {
        private readonly Game game = new Game();

        private Point cursorPosition;

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
            cursorPosition = new Point(e.X, e.Y);

            //For development
            label1.Text = (e.X - 242).ToString();
            label2.Text = (240 - e.Y).ToString();
            label3.Text = game.GetMasterKeyPosition();
        }

        private void DownKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                game.GamePhase = GamePhase.MoveScrewdriverClockWise;
        }

        private void UpKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                game.GamePhase = GamePhase.RotateMasterKey;
        }

        private void TickTimer(object sender, System.EventArgs e)
        {
            game.Update(cursorPosition);
            gameField.Refresh();
        }
    }
}
