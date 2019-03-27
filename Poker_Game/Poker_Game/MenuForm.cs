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
    public partial class MenuForm : Form
    {
        public Button buttonNewGame;
        public Button buttonStatistics;
        public Button buttonQuit;

        public MenuForm()
        {

            //Set the window form.
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);

            //Load background picture.
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            //initialize window of menuform
            InitializeComponent();
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);


            //Button, new game
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(500, 300);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // Event:
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Clicked);
            // Add the button to the form:
            Controls.Add(buttonNewGame);


            //Button, statistics
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(500, 200);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(75, 23);
            this.buttonStatistics.TabIndex = 0;
            this.buttonStatistics.Text = "Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            // Event:
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Clicked);
            // Add the button to the form:
            Controls.Add(buttonStatistics);


            //Button, quit
            this.buttonQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(500, 100);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            // Event:
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Clicked);
            // Add the button to the form:
            Controls.Add(buttonQuit);


        }
        public void buttonNewGame_Clicked(object sender, EventArgs e)
        {

        }
        public void buttonStatistics_Clicked(object sender, EventArgs e)
        {


        }
        public void buttonQuit_Clicked(object sender, EventArgs e)
        {


        }
    }
}
