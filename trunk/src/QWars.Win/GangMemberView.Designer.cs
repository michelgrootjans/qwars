using QWars.Presentation;

namespace QWars.Win
{
    partial class GangMemberView
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
            this.gridTasks = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExecuteTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTasks
            // 
            this.gridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTasks.Location = new System.Drawing.Point(0, 0);
            this.gridTasks.Name = "gridTasks";
            this.gridTasks.Size = new System.Drawing.Size(292, 227);
            this.gridTasks.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExecuteTask);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 46);
            this.panel1.TabIndex = 2;
            // 
            // btnExecuteTask
            // 
            this.btnExecuteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteTask.Location = new System.Drawing.Point(205, 11);
            this.btnExecuteTask.Name = "btnExecuteTask";
            this.btnExecuteTask.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteTask.TabIndex = 0;
            this.btnExecuteTask.Text = "Execute Task ...";
            this.btnExecuteTask.UseVisualStyleBackColor = true;
            this.btnExecuteTask.Click += new System.EventHandler(this.btnExecuteTask_Click);
            // 
            // GangMemberView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.gridTasks);
            this.Controls.Add(this.panel1);
            this.Name = "GangMemberView";
            this.Text = "Gang";
            this.Load += new System.EventHandler(this.GangMemberView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExecuteTask;
    }
}