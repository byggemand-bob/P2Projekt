﻿using System;
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
    public partial class MenuForm : Form
    {

        public MenuForm()
        {
            Icon = Properties.Resources.coins;


            //Set the window form.
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);

            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture.
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            //initialize window of menuform
            InitializeComponent();
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
        }

        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsForm formSettings = new SettingsForm();
            formSettings.ShowDialog();
            this.Close();
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
