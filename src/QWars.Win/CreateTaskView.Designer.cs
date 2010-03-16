using QWars.Presentation;

namespace QWars.Win
{
    partial class CreateTaskView
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDifficulty = new System.Windows.Forms.TextBox();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.txtXP = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Difficulty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reward";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "XP";
            // 
            // txtDifficulty
            // 
            this.txtDifficulty.Location = new System.Drawing.Point(65, 6);
            this.txtDifficulty.Name = "txtDifficulty";
            this.txtDifficulty.Size = new System.Drawing.Size(100, 20);
            this.txtDifficulty.TabIndex = 3;
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(65, 32);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(100, 20);
            this.txtReward.TabIndex = 4;
            // 
            // txtXP
            // 
            this.txtXP.Location = new System.Drawing.Point(65, 58);
            this.txtXP.Name = "txtXP";
            this.txtXP.Size = new System.Drawing.Size(100, 20);
            this.txtXP.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(90, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CreateTaskView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 123);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtXP);
            this.Controls.Add(this.txtReward);
            this.Controls.Add(this.txtDifficulty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateTaskView";
            this.Text = "Create Task";
            this.Load += new System.EventHandler(this.CreateTaskView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDifficulty;
        private System.Windows.Forms.TextBox txtReward;
        private System.Windows.Forms.TextBox txtXP;
        private System.Windows.Forms.Button btnOK;
    }
}