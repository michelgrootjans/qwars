namespace QWars.Win
{
    partial class BuyWeaponsView
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
            this.btnBuyClub = new System.Windows.Forms.Button();
            this.btnBuyKnife = new System.Windows.Forms.Button();
            this.btnBuyTaser = new System.Windows.Forms.Button();
            this.btnBuyGun = new System.Windows.Forms.Button();
            this.btnBuyBomb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuyClub
            // 
            this.btnBuyClub.Location = new System.Drawing.Point(12, 12);
            this.btnBuyClub.Name = "btnBuyClub";
            this.btnBuyClub.Size = new System.Drawing.Size(75, 23);
            this.btnBuyClub.TabIndex = 0;
            this.btnBuyClub.Text = "Club";
            this.btnBuyClub.UseVisualStyleBackColor = true;
            this.btnBuyClub.Click += new System.EventHandler(this.btnBuyClub_Click);
            // 
            // btnBuyKnife
            // 
            this.btnBuyKnife.Location = new System.Drawing.Point(12, 41);
            this.btnBuyKnife.Name = "btnBuyKnife";
            this.btnBuyKnife.Size = new System.Drawing.Size(75, 23);
            this.btnBuyKnife.TabIndex = 1;
            this.btnBuyKnife.Text = "Knife";
            this.btnBuyKnife.UseVisualStyleBackColor = true;
            this.btnBuyKnife.Click += new System.EventHandler(this.btnBuyKnife_Click);
            // 
            // btnBuyTaser
            // 
            this.btnBuyTaser.Location = new System.Drawing.Point(12, 70);
            this.btnBuyTaser.Name = "btnBuyTaser";
            this.btnBuyTaser.Size = new System.Drawing.Size(75, 23);
            this.btnBuyTaser.TabIndex = 2;
            this.btnBuyTaser.Text = "Taser";
            this.btnBuyTaser.UseVisualStyleBackColor = true;
            this.btnBuyTaser.Click += new System.EventHandler(this.btnBuyTaser_Click);
            // 
            // btnBuyGun
            // 
            this.btnBuyGun.Location = new System.Drawing.Point(110, 12);
            this.btnBuyGun.Name = "btnBuyGun";
            this.btnBuyGun.Size = new System.Drawing.Size(75, 23);
            this.btnBuyGun.TabIndex = 3;
            this.btnBuyGun.Text = "Gun";
            this.btnBuyGun.UseVisualStyleBackColor = true;
            this.btnBuyGun.Click += new System.EventHandler(this.btnBuyGun_Click);
            // 
            // btnBuyBomb
            // 
            this.btnBuyBomb.Location = new System.Drawing.Point(110, 41);
            this.btnBuyBomb.Name = "btnBuyBomb";
            this.btnBuyBomb.Size = new System.Drawing.Size(75, 23);
            this.btnBuyBomb.TabIndex = 4;
            this.btnBuyBomb.Text = "Bomb";
            this.btnBuyBomb.UseVisualStyleBackColor = true;
            this.btnBuyBomb.Click += new System.EventHandler(this.btnBuyBomb_Click);
            // 
            // BuyWeaponsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 107);
            this.Controls.Add(this.btnBuyBomb);
            this.Controls.Add(this.btnBuyGun);
            this.Controls.Add(this.btnBuyTaser);
            this.Controls.Add(this.btnBuyKnife);
            this.Controls.Add(this.btnBuyClub);
            this.Name = "BuyWeaponsView";
            this.Text = "Buy a new weapon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuyClub;
        private System.Windows.Forms.Button btnBuyKnife;
        private System.Windows.Forms.Button btnBuyTaser;
        private System.Windows.Forms.Button btnBuyGun;
        private System.Windows.Forms.Button btnBuyBomb;
    }
}