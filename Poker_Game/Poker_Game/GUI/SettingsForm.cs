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
        private bool nameChanged = false;

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

        private void textboxName_Leave(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                nameChanged = false;
            }
        }

        private void textboxName_Enter(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "Enter Name" && !nameChanged) {
                txtbox.Text = "";
            }
        }

        private void textbox_CheckChange(object sender, KeyPressEventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text != "" || txtbox.Text != "Enter Name") {
                nameChanged = true;
            }
        }
    }
}
