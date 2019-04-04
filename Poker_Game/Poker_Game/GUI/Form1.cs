using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set the window form.
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);

            //Load background picture.
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            //Load SettingsForm 
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            // Call
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            // Check
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            // Raise
        }
    }
}
