﻿// Autogenerated code by VS toolbox. Event-methods are in Form1.cs
using System;

namespace Poker_Game
{
    partial class SettingsForm
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
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.labelNumberOfPlayers = new System.Windows.Forms.Label();
            this.labelStackSize = new System.Windows.Forms.Label();
            this.labelBlindSize = new System.Windows.Forms.Label();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.trackBarNumberOfPlayers = new System.Windows.Forms.TrackBar();
            this.trackBarPotSize = new System.Windows.Forms.TrackBar();
            this.trackBarBlindSize = new System.Windows.Forms.TrackBar();
            this.numericUpDownNumberOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPotSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlindSize = new System.Windows.Forms.NumericUpDown();
            this.nameErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPotSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlindSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPotSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlindSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(148, 235);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(186, 68);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // labelNumberOfPlayers
            // 
            this.labelNumberOfPlayers.AutoSize = true;
            this.labelNumberOfPlayers.Location = new System.Drawing.Point(18, 21);
            this.labelNumberOfPlayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberOfPlayers.Name = "labelNumberOfPlayers";
            this.labelNumberOfPlayers.Size = new System.Drawing.Size(118, 16);
            this.labelNumberOfPlayers.TabIndex = 1;
            this.labelNumberOfPlayers.Text = "Number of players";
            // 
            // labelStackSize
            // 
            this.labelStackSize.AutoSize = true;
            this.labelStackSize.Location = new System.Drawing.Point(19, 77);
            this.labelStackSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStackSize.Name = "labelStackSize";
            this.labelStackSize.Size = new System.Drawing.Size(69, 16);
            this.labelStackSize.TabIndex = 2;
            this.labelStackSize.Text = "Stack size";
            // 
            // labelBlindSize
            // 
            this.labelBlindSize.AutoSize = true;
            this.labelBlindSize.Location = new System.Drawing.Point(18, 127);
            this.labelBlindSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlindSize.Name = "labelBlindSize";
            this.labelBlindSize.Size = new System.Drawing.Size(65, 16);
            this.labelBlindSize.TabIndex = 3;
            this.labelBlindSize.Text = "Blind size";
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(119, 190);
            this.labelPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(90, 16);
            this.labelPlayerName.TabIndex = 4;
            this.labelPlayerName.Text = "Player Name:";
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(243, 190);
            this.textboxName.Margin = new System.Windows.Forms.Padding(4);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(132, 22);
            this.textboxName.TabIndex = 2;
            this.textboxName.Text = "Enter Name";
            this.textboxName.Enter += new System.EventHandler(this.TextboxName_Enter);
            this.textboxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxName_KeyDown);
            this.textboxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_CheckChange);
            this.textboxName.Leave += new System.EventHandler(this.TextboxName_Leave);
            // 
            // trackBarNumberOfPlayers
            // 
            this.trackBarNumberOfPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarNumberOfPlayers.Enabled = false;
            this.trackBarNumberOfPlayers.Location = new System.Drawing.Point(134, 21);
            this.trackBarNumberOfPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarNumberOfPlayers.Maximum = 2;
            this.trackBarNumberOfPlayers.Minimum = 2;
            this.trackBarNumberOfPlayers.Name = "trackBarNumberOfPlayers";
            this.trackBarNumberOfPlayers.Size = new System.Drawing.Size(240, 45);
            this.trackBarNumberOfPlayers.TabIndex = 7;
            this.trackBarNumberOfPlayers.TabStop = false;
            this.trackBarNumberOfPlayers.Value = 2;
            this.trackBarNumberOfPlayers.ValueChanged += new System.EventHandler(this.NumberOfPlayersTrackBar_ValueChanged);
            // 
            // trackBarPotSize
            // 
            this.trackBarPotSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarPotSize.Location = new System.Drawing.Point(135, 72);
            this.trackBarPotSize.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarPotSize.Maximum = 10000;
            this.trackBarPotSize.Minimum = 100;
            this.trackBarPotSize.Name = "trackBarPotSize";
            this.trackBarPotSize.Size = new System.Drawing.Size(240, 45);
            this.trackBarPotSize.TabIndex = 0;
            this.trackBarPotSize.TabStop = false;
            this.trackBarPotSize.Value = 1000;
            this.trackBarPotSize.ValueChanged += new System.EventHandler(this.PotSizeTrackBar_ValueChanged);
            // 
            // trackBarBlindSize
            // 
            this.trackBarBlindSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarBlindSize.Location = new System.Drawing.Point(134, 121);
            this.trackBarBlindSize.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarBlindSize.Maximum = 1000;
            this.trackBarBlindSize.Minimum = 1;
            this.trackBarBlindSize.Name = "trackBarBlindSize";
            this.trackBarBlindSize.Size = new System.Drawing.Size(240, 45);
            this.trackBarBlindSize.TabIndex = 9;
            this.trackBarBlindSize.TabStop = false;
            this.trackBarBlindSize.Value = 1;
            this.trackBarBlindSize.ValueChanged += new System.EventHandler(this.TrackBarBlindSize_ValueChanged);
            // 
            // numericUpDownNumberOfPlayers
            // 
            this.numericUpDownNumberOfPlayers.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownNumberOfPlayers.Enabled = false;
            this.numericUpDownNumberOfPlayers.Location = new System.Drawing.Point(381, 21);
            this.numericUpDownNumberOfPlayers.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumberOfPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumberOfPlayers.Name = "numericUpDownNumberOfPlayers";
            this.numericUpDownNumberOfPlayers.Size = new System.Drawing.Size(76, 22);
            this.numericUpDownNumberOfPlayers.TabIndex = 10;
            this.numericUpDownNumberOfPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNumberOfPlayers.ValueChanged += new System.EventHandler(this.NumberOfPlayersNumericUpDown_ValueChanged);
            // 
            // numericUpDownPotSize
            // 
            this.numericUpDownPotSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownPotSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownPotSize.Location = new System.Drawing.Point(381, 72);
            this.numericUpDownPotSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPotSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPotSize.Name = "numericUpDownPotSize";
            this.numericUpDownPotSize.Size = new System.Drawing.Size(76, 22);
            this.numericUpDownPotSize.TabIndex = 0;
            this.numericUpDownPotSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPotSize.ValueChanged += new System.EventHandler(this.PotSizeNumericUpDown_ValueChanged);
            // 
            // numericUpDownBlindSize
            // 
            this.numericUpDownBlindSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownBlindSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBlindSize.Location = new System.Drawing.Point(381, 121);
            this.numericUpDownBlindSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBlindSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBlindSize.Name = "numericUpDownBlindSize";
            this.numericUpDownBlindSize.Size = new System.Drawing.Size(76, 22);
            this.numericUpDownBlindSize.TabIndex = 1;
            this.numericUpDownBlindSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBlindSize.ValueChanged += new System.EventHandler(this.BlindSizeNumericUpDown_ValueChanged);
            // 
            // nameErrorLabel
            // 
            this.nameErrorLabel.AutoSize = true;
            this.nameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.nameErrorLabel.Location = new System.Drawing.Point(243, 170);
            this.nameErrorLabel.Name = "nameErrorLabel";
            this.nameErrorLabel.Size = new System.Drawing.Size(137, 16);
            this.nameErrorLabel.TabIndex = 13;
            this.nameErrorLabel.Text = "Need to enter a name";
            this.nameErrorLabel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(469, 319);
            this.Controls.Add(this.nameErrorLabel);
            this.Controls.Add(this.numericUpDownBlindSize);
            this.Controls.Add(this.numericUpDownPotSize);
            this.Controls.Add(this.numericUpDownNumberOfPlayers);
            this.Controls.Add(this.trackBarBlindSize);
            this.Controls.Add(this.trackBarPotSize);
            this.Controls.Add(this.trackBarNumberOfPlayers);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.labelBlindSize);
            this.Controls.Add(this.labelStackSize);
            this.Controls.Add(this.labelNumberOfPlayers);
            this.Controls.Add(this.buttonStartGame);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPotSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlindSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPotSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlindSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void blindSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label labelNumberOfPlayers;
        private System.Windows.Forms.Label labelStackSize;
        private System.Windows.Forms.Label labelBlindSize;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.TrackBar trackBarNumberOfPlayers;
        private System.Windows.Forms.TrackBar trackBarPotSize;
        private System.Windows.Forms.TrackBar trackBarBlindSize;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfPlayers;
        private System.Windows.Forms.NumericUpDown numericUpDownPotSize;
        private System.Windows.Forms.NumericUpDown numericUpDownBlindSize;
        private System.Windows.Forms.Label nameErrorLabel;
    }
}
