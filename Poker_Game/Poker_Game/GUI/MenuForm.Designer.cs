namespace Poker_Game
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.Location = new System.Drawing.Point(546, 155);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(212, 103);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatistics.Location = new System.Drawing.Point(546, 351);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(212, 103);
            this.buttonStatistics.TabIndex = 1;
            this.buttonStatistics.Text = "Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.Location = new System.Drawing.Point(546, 547);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(212, 103);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::Poker_Game.Properties.Resources.PokerBord;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonStatistics);
            this.Controls.Add(this.buttonNewGame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Button buttonQuit;
    }
}