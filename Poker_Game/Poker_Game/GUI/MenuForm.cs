using System;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game.Properties;

namespace Poker_Game.GUI {
    public partial class MenuForm : Form {
        public MenuForm() {
            InitializeComponent();
            //Set the window form.
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
            Icon = Resources.coins;
            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture.
            BackgroundImage = Resources.PokerBord;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ButtonNewGame_Click(object sender, EventArgs e) {
            Hide();
            SettingsForm formSettings = new SettingsForm();
            formSettings.ShowDialog();
            Close();
        }

        private void ButtonQuit_Click(object sender, EventArgs e) {
            Close();
            Application.Exit();
        }
    }
}