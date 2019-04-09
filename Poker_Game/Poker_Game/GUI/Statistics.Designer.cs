namespace Poker_Game
{
    partial class Statistics
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
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Gray;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackToMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackToMenu.Location = new System.Drawing.Point(618, 12);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(170, 38);
            this.buttonBackToMenu.TabIndex = 0;
            this.buttonBackToMenu.Text = "Back to Menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // labelStatistics
            // 
            this.labelStatistics.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatistics.Location = new System.Drawing.Point(12, 91);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(505, 206);
            this.labelStatistics.TabIndex = 1;
            this.labelStatistics.Text = "Statistics info..";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.buttonBackToMenu);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.Label labelStatistics;
    }
}