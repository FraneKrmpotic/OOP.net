namespace WFApp.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlCountry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlRankedPlayerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRankedStadiumContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPlayerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFavoritePlayerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTest = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings,
            this.miPrint});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            resources.ApplyResources(this.miSettings, "miSettings");
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // miPrint
            // 
            this.miPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPreviewPrint,
            this.miPrintDocument});
            this.miPrint.Name = "miPrint";
            resources.ApplyResources(this.miPrint, "miPrint");
            // 
            // miPreviewPrint
            // 
            this.miPreviewPrint.Name = "miPreviewPrint";
            resources.ApplyResources(this.miPreviewPrint, "miPreviewPrint");
            this.miPreviewPrint.Click += new System.EventHandler(this.miPreviewPrint_Click);
            // 
            // miPrintDocument
            // 
            this.miPrintDocument.Name = "miPrintDocument";
            resources.ApplyResources(this.miPrintDocument, "miPrintDocument");
            this.miPrintDocument.Click += new System.EventHandler(this.miPrintDocument_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ddlCountry
            // 
            this.ddlCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCountry.FormattingEnabled = true;
            resources.ApplyResources(this.ddlCountry, "ddlCountry");
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.SelectedIndexChanged += new System.EventHandler(this.ddlCountry_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // pnlRankedPlayerContainer
            // 
            resources.ApplyResources(this.pnlRankedPlayerContainer, "pnlRankedPlayerContainer");
            this.pnlRankedPlayerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRankedPlayerContainer.Name = "pnlRankedPlayerContainer";
            // 
            // pnlRankedStadiumContainer
            // 
            resources.ApplyResources(this.pnlRankedStadiumContainer, "pnlRankedStadiumContainer");
            this.pnlRankedStadiumContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRankedStadiumContainer.Name = "pnlRankedStadiumContainer";
            // 
            // pnlPlayerContainer
            // 
            this.pnlPlayerContainer.AllowDrop = true;
            resources.ApplyResources(this.pnlPlayerContainer, "pnlPlayerContainer");
            this.pnlPlayerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayerContainer.Name = "pnlPlayerContainer";
            // 
            // pnlFavoritePlayerContainer
            // 
            this.pnlFavoritePlayerContainer.AllowDrop = true;
            resources.ApplyResources(this.pnlFavoritePlayerContainer, "pnlFavoritePlayerContainer");
            this.pnlFavoritePlayerContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFavoritePlayerContainer.Name = "pnlFavoritePlayerContainer";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            resources.ApplyResources(this.lblInfo, "lblInfo");
            // 
            // lblTest
            // 
            resources.ApplyResources(this.lblTest, "lblTest");
            this.lblTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTest.Name = "lblTest";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlFavoritePlayerContainer);
            this.Controls.Add(this.pnlPlayerContainer);
            this.Controls.Add(this.pnlRankedStadiumContainer);
            this.Controls.Add(this.pnlRankedPlayerContainer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedPlayerContainer;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedStadiumContainer;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayerContainer;
        private System.Windows.Forms.FlowLayoutPanel pnlFavoritePlayerContainer;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ToolStripMenuItem miPreviewPrint;
        private System.Windows.Forms.ToolStripMenuItem miPrintDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.Label lblTest;
    }
}