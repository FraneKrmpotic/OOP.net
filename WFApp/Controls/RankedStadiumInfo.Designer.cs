namespace WFApp.Controls
{
    partial class RankedStadiumInfo
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
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblVisitors = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(28, 24);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 16);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "location";
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.AutoSize = true;
            this.lblHomeTeam.Location = new System.Drawing.Point(28, 59);
            this.lblHomeTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(77, 16);
            this.lblHomeTeam.TabIndex = 4;
            this.lblHomeTeam.Text = "homeTeam";
            // 
            // lblVisitors
            // 
            this.lblVisitors.AutoSize = true;
            this.lblVisitors.Location = new System.Drawing.Point(232, 24);
            this.lblVisitors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVisitors.Name = "lblVisitors";
            this.lblVisitors.Size = new System.Drawing.Size(49, 16);
            this.lblVisitors.TabIndex = 5;
            this.lblVisitors.Text = "visitors";
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.AutoSize = true;
            this.lblAwayTeam.Location = new System.Drawing.Point(232, 59);
            this.lblAwayTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(75, 16);
            this.lblAwayTeam.TabIndex = 6;
            this.lblAwayTeam.Text = "awayTeam";
            // 
            // RankedStadiumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.lblVisitors);
            this.Controls.Add(this.lblHomeTeam);
            this.Controls.Add(this.lblLocation);
            this.Name = "RankedStadiumInfo";
            this.Size = new System.Drawing.Size(340, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblVisitors;
        private System.Windows.Forms.Label lblAwayTeam;
    }
}
