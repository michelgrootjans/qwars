namespace QWars.Win
{
    partial class CreateGangView
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGangName = new System.Windows.Forms.TextBox();
            this.txtBossBenefit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gang name";
            // 
            // txtGangName
            // 
            this.txtGangName.Location = new System.Drawing.Point(80, 6);
            this.txtGangName.Name = "txtGangName";
            this.txtGangName.Size = new System.Drawing.Size(207, 20);
            this.txtGangName.TabIndex = 1;
            // 
            // txtBossBenefit
            // 
            this.txtBossBenefit.Location = new System.Drawing.Point(123, 32);
            this.txtBossBenefit.Name = "txtBossBenefit";
            this.txtBossBenefit.Size = new System.Drawing.Size(35, 20);
            this.txtBossBenefit.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Earnings for Boss(%)";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(212, 65);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CreateGangView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 94);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBossBenefit);
            this.Controls.Add(this.txtGangName);
            this.Controls.Add(this.label1);
            this.Name = "CreateGangView";
            this.Text = "Create Gang";
            this.Load += new System.EventHandler(this.CreateGangView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGangName;
        private System.Windows.Forms.TextBox txtBossBenefit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
    }
}