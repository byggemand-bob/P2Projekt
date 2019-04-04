using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            
            
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm formGame = new GameForm();
            formGame.ShowDialog();
            this.Close();
        }
    }
}
