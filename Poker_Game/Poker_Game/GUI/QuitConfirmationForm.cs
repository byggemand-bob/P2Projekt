using System;
using System.Windows.Forms;

namespace Poker_Game.GUI
{
    public partial class QuitConfirmationForm : Form
    {
        public GameForm _gameFormQuit1;
        public QuitConfirmationForm(GameForm gameFormQuit)
        {
            InitializeComponent();
            Icon = Properties.Resources.coins;
            StartPosition = FormStartPosition.CenterScreen;

            _gameFormQuit1 = gameFormQuit;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.Hide();
            _gameFormQuit1.Hide();

            MenuForm formMenu = new MenuForm();
            formMenu.ShowDialog();

            this.Close();
            _gameFormQuit1.Close();
        }

        private void QuitConfirmationForm_Load(object sender, EventArgs e) {

        }
    }
}
