namespace QWars.Win
{
    partial class AdministratorView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridReport = new System.Windows.Forms.DataGridView();
            this.btnTopPlayers = new System.Windows.Forms.Button();
            this.btnBiggestGangs = new System.Windows.Forms.Button();
            this.btnRichestPlayer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRichestPlayer);
            this.panel1.Controls.Add(this.btnBiggestGangs);
            this.panel1.Controls.Add(this.btnTopPlayers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 324);
            this.panel1.TabIndex = 0;
            // 
            // gridReport
            // 
            this.gridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReport.Location = new System.Drawing.Point(168, 0);
            this.gridReport.Name = "gridReport";
            this.gridReport.Size = new System.Drawing.Size(523, 324);
            this.gridReport.TabIndex = 1;
            // 
            // btnTopPlayers
            // 
            this.btnTopPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopPlayers.Location = new System.Drawing.Point(12, 12);
            this.btnTopPlayers.Name = "btnTopPlayers";
            this.btnTopPlayers.Size = new System.Drawing.Size(150, 23);
            this.btnTopPlayers.TabIndex = 0;
            this.btnTopPlayers.Text = "Top players";
            this.btnTopPlayers.UseVisualStyleBackColor = true;
            this.btnTopPlayers.Click += new System.EventHandler(this.btnTopPlayers_Click);
            // 
            // btnBiggestGangs
            // 
            this.btnBiggestGangs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBiggestGangs.Location = new System.Drawing.Point(12, 70);
            this.btnBiggestGangs.Name = "btnBiggestGangs";
            this.btnBiggestGangs.Size = new System.Drawing.Size(150, 23);
            this.btnBiggestGangs.TabIndex = 1;
            this.btnBiggestGangs.Text = "Biggest Gangs";
            this.btnBiggestGangs.UseVisualStyleBackColor = true;
            this.btnBiggestGangs.Click += new System.EventHandler(this.btnBiggestGangs_Click);
            // 
            // btnRichestPlayer
            // 
            this.btnRichestPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRichestPlayer.Location = new System.Drawing.Point(12, 41);
            this.btnRichestPlayer.Name = "btnRichestPlayer";
            this.btnRichestPlayer.Size = new System.Drawing.Size(150, 23);
            this.btnRichestPlayer.TabIndex = 2;
            this.btnRichestPlayer.Text = "RichestPlayer";
            this.btnRichestPlayer.UseVisualStyleBackColor = true;
            this.btnRichestPlayer.Click += new System.EventHandler(this.btnRichestPlayer_Click);
            // 
            // AdministratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 324);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.panel1);
            this.Name = "AdministratorView";
            this.Text = "AdministratorView";
            this.Load += new System.EventHandler(this.AdministratorView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridReport;
        private System.Windows.Forms.Button btnRichestPlayer;
        private System.Windows.Forms.Button btnBiggestGangs;
        private System.Windows.Forms.Button btnTopPlayers;
    }
}