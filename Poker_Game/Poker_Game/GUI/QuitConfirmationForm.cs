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
    public partial class QuitConfirmationForm : Form
    {
        GameForm GameFormQuit1;
        public QuitConfirmationForm(GameForm GameFormQuit)
        {
            InitializeComponent();
            GameFormQuit1 = GameFormQuit;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameFormQuit1.Hide();

            MenuForm formMenu = new MenuForm();
            formMenu.ShowDialog();

            this.Close();
            GameFormQuit1.Close();
        }
    }
}
