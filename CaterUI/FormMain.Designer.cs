namespace CaterUI
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManagerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMemberInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTableInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDishInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrderInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::CaterUI.Properties.Resources.menuBg;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManagerInfo,
            this.menuMemberInfo,
            this.menuTableInfo,
            this.menuDishInfo,
            this.menuOrderInfo,
            this.MenuQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(474, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManagerInfo
            // 
            this.menuManagerInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManagerInfo.Image = global::CaterUI.Properties.Resources.menuManager;
            this.menuManagerInfo.Name = "menuManagerInfo";
            this.menuManagerInfo.Size = new System.Drawing.Size(76, 68);
            this.menuManagerInfo.Text = "toolStripMenuItem1";
            // 
            // menuMemberInfo
            // 
            this.menuMemberInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMemberInfo.Image = global::CaterUI.Properties.Resources.menuMember;
            this.menuMemberInfo.Name = "menuMemberInfo";
            this.menuMemberInfo.Size = new System.Drawing.Size(76, 68);
            this.menuMemberInfo.Text = "toolStripMenuItem2";
            // 
            // menuTableInfo
            // 
            this.menuTableInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuTableInfo.Image = global::CaterUI.Properties.Resources.menuTable;
            this.menuTableInfo.Name = "menuTableInfo";
            this.menuTableInfo.Size = new System.Drawing.Size(76, 68);
            this.menuTableInfo.Text = "toolStripMenuItem3";
            // 
            // menuDishInfo
            // 
            this.menuDishInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDishInfo.Image = global::CaterUI.Properties.Resources.menuDish;
            this.menuDishInfo.Name = "menuDishInfo";
            this.menuDishInfo.Size = new System.Drawing.Size(76, 68);
            this.menuDishInfo.Text = "toolStripMenuItem4";
            // 
            // menuOrderInfo
            // 
            this.menuOrderInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOrderInfo.Image = global::CaterUI.Properties.Resources.menuOrder;
            this.menuOrderInfo.Name = "menuOrderInfo";
            this.menuOrderInfo.Size = new System.Drawing.Size(76, 68);
            this.menuOrderInfo.Text = "toolStripMenuItem5";
            // 
            // MenuQuit
            // 
            this.MenuQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuQuit.Image = global::CaterUI.Properties.Resources.menuQuit;
            this.MenuQuit.Name = "MenuQuit";
            this.MenuQuit.Size = new System.Drawing.Size(76, 68);
            this.MenuQuit.Text = "toolStripMenuItem6";
            this.MenuQuit.Click += new System.EventHandler(this.MenuQuit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 365);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManagerInfo;
        private System.Windows.Forms.ToolStripMenuItem menuMemberInfo;
        private System.Windows.Forms.ToolStripMenuItem menuTableInfo;
        private System.Windows.Forms.ToolStripMenuItem menuDishInfo;
        private System.Windows.Forms.ToolStripMenuItem menuOrderInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuQuit;
    }
}