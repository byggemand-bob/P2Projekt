﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker_Game.GUI
{
    public partial class MenuForm : Form
    {

        public MenuForm()
        {
            Icon = Properties.Resources.coins;
            //Set the window form.
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);

            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture.
            BackgroundImage = Properties.Resources.PokerBord;
            BackgroundImageLayout = ImageLayout.Stretch;


            //initialize window of menuform
            InitializeComponent();
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
        }

        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsForm formSettings = new SettingsForm();
            formSettings.ShowDialog();
            Close();
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
