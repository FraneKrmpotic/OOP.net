namespace WFApp.Controls
{
    partial class RankedPlayerInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblGoals = new System.Windows.Forms.Label();
            this.lblYellowCards = new System.Windows.Forms.Label();
            this.pbRankedPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRankedPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "name";
            // 
            // lblGoals
            // 
            this.lblGoals.AutoSize = true;
            this.lblGoals.Location = new System.Drawing.Point(27, 45);
            this.lblGoals.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGoals.Name = "lblGoals";
            this.lblGoals.Size = new System.Drawing.Size(41, 16);
            this.lblGoals.TabIndex = 3;
            this.lblGoals.Text = "goals";
            // 
            // lblYellowCards
            // 
            this.lblYellowCards.AutoSize = true;
            this.lblYellowCards.Location = new System.Drawing.Point(27, 72);
            this.lblYellowCards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYellowCards.Name = "lblYellowCards";
            this.lblYellowCards.Size = new System.Drawing.Size(41, 16);
            this.lblYellowCards.TabIndex = 4;
            this.lblYellowCards.Text = "cards";
            // 
            // pbRankedPlayer
            // 
            this.pbRankedPlayer.Location = new System.Drawing.Point(229, 0);
            this.pbRankedPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.pbRankedPlayer.Name = "pbRankedPlayer";
            this.pbRankedPlayer.Size = new System.Drawing.Size(111, 100);
            this.pbRankedPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRankedPlayer.TabIndex = 6;
            this.pbRankedPlayer.TabStop = false;
            // 
            // RankedPlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pbRankedPlayer);
            this.Controls.Add(this.lblYellowCards);
            this.Controls.Add(this.lblGoals);
            this.Controls.Add(this.lblName);
            this.Name = "RankedPlayerInfo";
            this.Size = new System.Drawing.Size(340, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pbRankedPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGoals;
        private System.Windows.Forms.Label lblYellowCards;
        private System.Windows.Forms.PictureBox pbRankedPlayer;
    }
}
