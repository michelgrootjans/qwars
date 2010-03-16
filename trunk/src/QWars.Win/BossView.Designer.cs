using QWars.Presentation;

namespace QWars.Win
{
    partial class BossView : IBossView
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.gridMembers = new System.Windows.Forms.DataGridView();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.gridTasks = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIncreaseReward = new System.Windows.Forms.Button();
            this.btnCreateRandomTasks = new System.Windows.Forms.Button();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblNumberOfMembers = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).BeginInit();
            this.tabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMembers);
            this.tabs.Controls.Add(this.tabTasks);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 59);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(403, 396);
            this.tabs.TabIndex = 0;
            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.gridMembers);
            this.tabMembers.Location = new System.Drawing.Point(4, 22);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembers.Size = new System.Drawing.Size(395, 370);
            this.tabMembers.TabIndex = 0;
            this.tabMembers.Text = "Members";
            this.tabMembers.UseVisualStyleBackColor = true;
            // 
            // gridMembers
            // 
            this.gridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMembers.Location = new System.Drawing.Point(3, 3);
            this.gridMembers.Name = "gridMembers";
            this.gridMembers.Size = new System.Drawing.Size(389, 364);
            this.gridMembers.TabIndex = 0;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.gridTasks);
            this.tabTasks.Controls.Add(this.panel1);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(395, 370);
            this.tabTasks.TabIndex = 1;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // gridTasks
            // 
            this.gridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTasks.Location = new System.Drawing.Point(3, 3);
            this.gridTasks.Name = "gridTasks";
            this.gridTasks.Size = new System.Drawing.Size(389, 292);
            this.gridTasks.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIncreaseReward);
            this.panel1.Controls.Add(this.btnCreateRandomTasks);
            this.panel1.Controls.Add(this.btnCreateTask);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 72);
            this.panel1.TabIndex = 0;
            // 
            // btnIncreaseReward
            // 
            this.btnIncreaseReward.Location = new System.Drawing.Point(222, 35);
            this.btnIncreaseReward.Name = "btnIncreaseReward";
            this.btnIncreaseReward.Size = new System.Drawing.Size(162, 23);
            this.btnIncreaseReward.TabIndex = 2;
            this.btnIncreaseReward.Text = "Increase Reward For All Tasks";
            this.btnIncreaseReward.UseVisualStyleBackColor = true;
            this.btnIncreaseReward.Click += new System.EventHandler(this.btnIncreaseReward_Click);
            // 
            // btnCreateRandomTasks
            // 
            this.btnCreateRandomTasks.Location = new System.Drawing.Point(222, 6);
            this.btnCreateRandomTasks.Name = "btnCreateRandomTasks";
            this.btnCreateRandomTasks.Size = new System.Drawing.Size(162, 23);
            this.btnCreateRandomTasks.TabIndex = 1;
            this.btnCreateRandomTasks.Text = "Create 20 Random Tasks";
            this.btnCreateRandomTasks.UseVisualStyleBackColor = true;
            this.btnCreateRandomTasks.Click += new System.EventHandler(this.btnCreateRandomTasks_Click);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(5, 6);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(98, 23);
            this.btnCreateTask.TabIndex = 0;
            this.btnCreateTask.Text = "Create Task ...";
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMoney);
            this.panel2.Controls.Add(this.lblNumberOfMembers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 59);
            this.panel2.TabIndex = 1;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(4, 31);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(39, 13);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "Money";
            // 
            // lblNumberOfMembers
            // 
            this.lblNumberOfMembers.AutoSize = true;
            this.lblNumberOfMembers.Location = new System.Drawing.Point(4, 9);
            this.lblNumberOfMembers.Name = "lblNumberOfMembers";
            this.lblNumberOfMembers.Size = new System.Drawing.Size(56, 13);
            this.lblNumberOfMembers.TabIndex = 0;
            this.lblNumberOfMembers.Text = "#members";
            // 
            // BossView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 455);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panel2);
            this.Name = "BossView";
            this.Text = "BossView";
            this.Load += new System.EventHandler(this.BossView_Load);
            this.tabs.ResumeLayout(false);
            this.tabMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMembers)).EndInit();
            this.tabTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.DataGridView gridMembers;
        private System.Windows.Forms.DataGridView gridTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateRandomTasks;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnIncreaseReward;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblNumberOfMembers;
    }
}