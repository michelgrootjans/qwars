namespace QWars.Win
{
    partial class PlayerView
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
            this.btnBuyWeapon = new System.Windows.Forms.Button();
            this.btnJoinGang = new System.Windows.Forms.Button();
            this.btnCreateGang = new System.Windows.Forms.Button();
            this.btnMug = new System.Windows.Forms.Button();
            this.btnSellUnusedWeapons = new System.Windows.Forms.Button();
            this.lstWeapons = new System.Windows.Forms.DataGridView();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.tabWeapons = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabGang = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewGang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lstWeapons)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.tabWeapons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabGang.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuyWeapon
            // 
            this.btnBuyWeapon.Location = new System.Drawing.Point(12, 15);
            this.btnBuyWeapon.Name = "btnBuyWeapon";
            this.btnBuyWeapon.Size = new System.Drawing.Size(94, 23);
            this.btnBuyWeapon.TabIndex = 0;
            this.btnBuyWeapon.Text = "Buy Weapon ...";
            this.btnBuyWeapon.UseVisualStyleBackColor = true;
            this.btnBuyWeapon.Click += new System.EventHandler(this.btnBuyWeapon_Click);
            // 
            // btnJoinGang
            // 
            this.btnJoinGang.Location = new System.Drawing.Point(8, 10);
            this.btnJoinGang.Name = "btnJoinGang";
            this.btnJoinGang.Size = new System.Drawing.Size(134, 23);
            this.btnJoinGang.TabIndex = 1;
            this.btnJoinGang.Text = "Join Gang ...";
            this.btnJoinGang.UseVisualStyleBackColor = true;
            this.btnJoinGang.Click += new System.EventHandler(this.btnJoinGang_Click);
            // 
            // btnCreateGang
            // 
            this.btnCreateGang.Location = new System.Drawing.Point(8, 39);
            this.btnCreateGang.Name = "btnCreateGang";
            this.btnCreateGang.Size = new System.Drawing.Size(134, 23);
            this.btnCreateGang.TabIndex = 2;
            this.btnCreateGang.Text = "Create Gang ...";
            this.btnCreateGang.UseVisualStyleBackColor = true;
            this.btnCreateGang.Click += new System.EventHandler(this.btnCreateGang_Click);
            // 
            // btnMug
            // 
            this.btnMug.Location = new System.Drawing.Point(11, 16);
            this.btnMug.Name = "btnMug";
            this.btnMug.Size = new System.Drawing.Size(121, 23);
            this.btnMug.TabIndex = 3;
            this.btnMug.Text = "Mug Pedestrian";
            this.btnMug.UseVisualStyleBackColor = true;
            this.btnMug.Click += new System.EventHandler(this.btnMug_Click);
            // 
            // btnSellUnusedWeapons
            // 
            this.btnSellUnusedWeapons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSellUnusedWeapons.Location = new System.Drawing.Point(270, 15);
            this.btnSellUnusedWeapons.Name = "btnSellUnusedWeapons";
            this.btnSellUnusedWeapons.Size = new System.Drawing.Size(137, 23);
            this.btnSellUnusedWeapons.TabIndex = 4;
            this.btnSellUnusedWeapons.Text = "Sell unused weapons";
            this.btnSellUnusedWeapons.UseVisualStyleBackColor = true;
            this.btnSellUnusedWeapons.Click += new System.EventHandler(this.btnSellUnusedWeapons_Click);
            // 
            // lstWeapons
            // 
            this.lstWeapons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWeapons.Location = new System.Drawing.Point(3, 3);
            this.lstWeapons.Name = "lstWeapons";
            this.lstWeapons.Size = new System.Drawing.Size(412, 201);
            this.lstWeapons.TabIndex = 6;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabTasks);
            this.tabs.Controls.Add(this.tabWeapons);
            this.tabs.Controls.Add(this.tabGang);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 63);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(426, 284);
            this.tabs.TabIndex = 7;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.btnMug);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(418, 258);
            this.tabTasks.TabIndex = 0;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // tabWeapons
            // 
            this.tabWeapons.Controls.Add(this.lstWeapons);
            this.tabWeapons.Controls.Add(this.panel1);
            this.tabWeapons.Location = new System.Drawing.Point(4, 22);
            this.tabWeapons.Name = "tabWeapons";
            this.tabWeapons.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeapons.Size = new System.Drawing.Size(418, 258);
            this.tabWeapons.TabIndex = 1;
            this.tabWeapons.Text = "Weapons";
            this.tabWeapons.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuyWeapon);
            this.panel1.Controls.Add(this.btnSellUnusedWeapons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 51);
            this.panel1.TabIndex = 7;
            // 
            // tabGang
            // 
            this.tabGang.Controls.Add(this.btnViewGang);
            this.tabGang.Controls.Add(this.btnJoinGang);
            this.tabGang.Controls.Add(this.btnCreateGang);
            this.tabGang.Location = new System.Drawing.Point(4, 22);
            this.tabGang.Name = "tabGang";
            this.tabGang.Padding = new System.Windows.Forms.Padding(3);
            this.tabGang.Size = new System.Drawing.Size(418, 258);
            this.tabGang.TabIndex = 2;
            this.tabGang.Text = "Gang";
            this.tabGang.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMoney);
            this.panel2.Controls.Add(this.lblExperience);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 63);
            this.panel2.TabIndex = 8;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(78, 31);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(39, 13);
            this.lblMoney.TabIndex = 4;
            this.lblMoney.Text = "Money";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(78, 9);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(60, 13);
            this.lblExperience.TabIndex = 3;
            this.lblExperience.Text = "Experience";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Money";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Experience";
            // 
            // btnViewGang
            // 
            this.btnViewGang.Location = new System.Drawing.Point(8, 68);
            this.btnViewGang.Name = "btnViewGang";
            this.btnViewGang.Size = new System.Drawing.Size(134, 23);
            this.btnViewGang.TabIndex = 3;
            this.btnViewGang.Text = "View gang ...";
            this.btnViewGang.UseVisualStyleBackColor = true;
            this.btnViewGang.Click += new System.EventHandler(this.btnViewGang_Click);
            // 
            // PlayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 347);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panel2);
            this.Name = "PlayerView";
            this.Text = "PlayerView";
            this.Load += new System.EventHandler(this.PlayerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstWeapons)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.tabWeapons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabGang.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuyWeapon;
        private System.Windows.Forms.Button btnJoinGang;
        private System.Windows.Forms.Button btnCreateGang;
        private System.Windows.Forms.Button btnMug;
        private System.Windows.Forms.Button btnSellUnusedWeapons;
        private System.Windows.Forms.DataGridView lstWeapons;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.TabPage tabWeapons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabGang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewGang;
    }
}