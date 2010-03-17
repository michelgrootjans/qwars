namespace QWars.Win
{
    partial class JoinGangView
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
            this.btnJoinGang = new System.Windows.Forms.Button();
            this.gridGangs = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGangs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnJoinGang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnJoinGang
            // 
            this.btnJoinGang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoinGang.Location = new System.Drawing.Point(205, 11);
            this.btnJoinGang.Name = "btnJoinGang";
            this.btnJoinGang.Size = new System.Drawing.Size(75, 23);
            this.btnJoinGang.TabIndex = 0;
            this.btnJoinGang.Text = "Join Gang";
            this.btnJoinGang.UseVisualStyleBackColor = true;
            this.btnJoinGang.Click += new System.EventHandler(this.btnJoinGang_Click);
            // 
            // gridGangs
            // 
            this.gridGangs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGangs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGangs.Location = new System.Drawing.Point(0, 0);
            this.gridGangs.Name = "gridGangs";
            this.gridGangs.Size = new System.Drawing.Size(292, 227);
            this.gridGangs.TabIndex = 1;
            // 
            // JoinGangView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.gridGangs);
            this.Controls.Add(this.panel1);
            this.Name = "JoinGangView";
            this.Text = "Join gang";
            this.Load += new System.EventHandler(this.JoinGangView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGangs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnJoinGang;
        private System.Windows.Forms.DataGridView gridGangs;
    }
}