namespace ChangeDNS.App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            label1 = new Label();
            BtnExit = new Button();
            NotifyApp = new NotifyIcon(components);
            ContextMenuNotify = new ContextMenuStrip(components);
            ToolMenuShowApp = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolMenuExit = new ToolStripMenuItem();
            label2 = new Label();
            ComboBoxDNS = new ComboBox();
            BtnChangeDns = new Button();
            BtnResetDns = new Button();
            BtnRestartAdapter = new Button();
            lblStatus = new Label();
            ContextMenuNotify.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 255, 192);
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(116, 18);
            label1.TabIndex = 5;
            label1.Text = "DNS Changer";
            // 
            // BtnExit
            // 
            BtnExit.Cursor = Cursors.Hand;
            BtnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnExit.ForeColor = Color.White;
            BtnExit.Location = new Point(239, 8);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(25, 23);
            BtnExit.TabIndex = 4;
            BtnExit.Text = "X";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // NotifyApp
            // 
            NotifyApp.ContextMenuStrip = ContextMenuNotify;
            NotifyApp.Icon = (Icon)resources.GetObject("NotifyApp.Icon");
            NotifyApp.Text = "DNS Changer ©2024";
            NotifyApp.Visible = true;
            // 
            // ContextMenuNotify
            // 
            ContextMenuNotify.Items.AddRange(new ToolStripItem[] { ToolMenuShowApp, ToolStripSeparator1, ToolMenuExit });
            ContextMenuNotify.Name = "contextMenuNotify";
            ContextMenuNotify.Size = new Size(129, 54);
            // 
            // ToolMenuShowApp
            // 
            ToolMenuShowApp.Name = "ToolMenuShowApp";
            ToolMenuShowApp.Size = new Size(128, 22);
            ToolMenuShowApp.Text = "Show App";
            ToolMenuShowApp.Click += ToolMenuShowApp_Click;
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(125, 6);
            // 
            // ToolMenuExit
            // 
            ToolMenuExit.Name = "ToolMenuExit";
            ToolMenuExit.Size = new Size(128, 22);
            ToolMenuExit.Text = "Exit";
            ToolMenuExit.Click += ToolMenuExit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 64, 64);
            label2.Location = new Point(71, 376);
            label2.Name = "label2";
            label2.Size = new Size(122, 17);
            label2.TabIndex = 7;
            label2.Text = "www.nimazare.org";
            // 
            // ComboBoxDNS
            // 
            ComboBoxDNS.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxDNS.FormattingEnabled = true;
            ComboBoxDNS.Items.AddRange(new object[] { "403.online DNS", "Shecan DNS", "Gcore Public DNS", "Quad9", "OpenDNS", "Cloudflare" });
            ComboBoxDNS.Location = new Point(43, 69);
            ComboBoxDNS.Name = "ComboBoxDNS";
            ComboBoxDNS.Size = new Size(179, 23);
            ComboBoxDNS.TabIndex = 0;
            // 
            // BtnChangeDns
            // 
            BtnChangeDns.Cursor = Cursors.Hand;
            BtnChangeDns.FlatAppearance.BorderSize = 2;
            BtnChangeDns.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            BtnChangeDns.FlatStyle = FlatStyle.Flat;
            BtnChangeDns.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnChangeDns.ForeColor = Color.Lime;
            BtnChangeDns.Location = new Point(30, 150);
            BtnChangeDns.Name = "BtnChangeDns";
            BtnChangeDns.Size = new Size(209, 39);
            BtnChangeDns.TabIndex = 1;
            BtnChangeDns.Text = "Change DNS";
            BtnChangeDns.UseVisualStyleBackColor = true;
            BtnChangeDns.Click += BtnChangeDns_Click;
            // 
            // BtnResetDns
            // 
            BtnResetDns.Cursor = Cursors.Hand;
            BtnResetDns.FlatAppearance.BorderSize = 2;
            BtnResetDns.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnResetDns.FlatStyle = FlatStyle.Flat;
            BtnResetDns.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnResetDns.ForeColor = Color.White;
            BtnResetDns.Location = new Point(30, 195);
            BtnResetDns.Name = "BtnResetDns";
            BtnResetDns.Size = new Size(209, 39);
            BtnResetDns.TabIndex = 2;
            BtnResetDns.Text = "Reset DNS";
            BtnResetDns.UseVisualStyleBackColor = true;
            BtnResetDns.Click += BtnResetDns_Click;
            // 
            // BtnRestartAdapter
            // 
            BtnRestartAdapter.Cursor = Cursors.Hand;
            BtnRestartAdapter.FlatAppearance.BorderSize = 2;
            BtnRestartAdapter.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            BtnRestartAdapter.FlatStyle = FlatStyle.Flat;
            BtnRestartAdapter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRestartAdapter.ForeColor = Color.Crimson;
            BtnRestartAdapter.Location = new Point(30, 240);
            BtnRestartAdapter.Name = "BtnRestartAdapter";
            BtnRestartAdapter.Size = new Size(209, 39);
            BtnRestartAdapter.TabIndex = 3;
            BtnRestartAdapter.Text = "Restart Network Adapter";
            BtnRestartAdapter.UseVisualStyleBackColor = true;
            BtnRestartAdapter.Click += BtnRestartAdapter_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(255, 255, 128);
            lblStatus.Location = new Point(87, 310);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 17);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Disconnected";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(270, 400);
            Controls.Add(lblStatus);
            Controls.Add(BtnRestartAdapter);
            Controls.Add(BtnResetDns);
            Controls.Add(BtnChangeDns);
            Controls.Add(ComboBoxDNS);
            Controls.Add(label2);
            Controls.Add(BtnExit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Opacity = 0.95D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "DNS Changer ©2024";
            Load += Main_Load;
            ContextMenuNotify.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BtnExit;
        private NotifyIcon NotifyApp;
        private ContextMenuStrip ContextMenuNotify;
        private ToolStripMenuItem ToolMenuShowApp;
        private ToolStripSeparator ToolStripSeparator1;
        private ToolStripMenuItem ToolMenuExit;
        private Label label2;
        private ComboBox ComboBoxDNS;
        private Button BtnChangeDns;
        private Button BtnResetDns;
        private Button BtnRestartAdapter;
        private Label lblStatus;
    }
}
