using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lock
{
    public partial class MainForm : Form
    {
        private Game game = new Game();

        public MainForm()
        {
            InitializeComponent();

            gameField.Paint += Draw;

            game.StartNewGame();
        }

        private void TickTimer(object sender, System.EventArgs e)
        {
            game.Update();
            gameField.Refresh();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            game.Draw(e.Graphics);
        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            game.RotateMasterKey(e.X, e.Y);
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

        private void DownKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                game.StartLocking();
        }

        private void UpKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                game.StopLocking();
        }
    }
}
