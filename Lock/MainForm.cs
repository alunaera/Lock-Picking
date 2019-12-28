using System.Drawing;
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

            game.StartNewGame();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            game.Draw(e.Graphics);
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            game.CursorPosition = new Point(e.X, e.Y);
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
            game.Update();
            gameField.Refresh();
        }

        private void ClickNewGame(object sender, System.EventArgs e)
        {
            game.StartNewGame();
        }

        private void ClickHelp(object sender, System.EventArgs e)
        {
            MessageBox.Show("Move mouse - rotate master key \n" +
                            "Press Space - start lock's opening");
        }
    }
}
