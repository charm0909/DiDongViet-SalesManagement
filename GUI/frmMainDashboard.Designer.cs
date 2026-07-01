namespace DiDongViet_SalesManagement.GUI
{
    partial class frmMainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinh DoanhtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐƠnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.hệThốngToolStripMenuItem, this.quảnLýToolStripMenuItem, this.kinh DoanhtoolStripMenuItem, this.báoCaoToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.đăngXuấtToolStripMenuItem });
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";

            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);

            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.sảnPhẩmToolStripMenuItem, this.nhânViênToolStripMenuItem, this.kháchHàngToolStripMenuItem, this.nhàCungCấpToolStripMenuItem });
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";

            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);

            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);

            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);

            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);

            this.kinh DoanhtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.hóaĐƠnToolStripMenuItem, this.nhậpHàngToolStripMenuItem, this.khoToolStripMenuItem });
            this.kinh DoanhtoolStripMenuItem.Name = "kinh DoanhtoolStripMenuItem";
            this.kinh DoanhtoolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.kinh DoanhtoolStripMenuItem.Text = "Kinh doanh";

            this.hóaĐƠnToolStripMenuItem.Name = "hóaĐƠnToolStripMenuItem";
            this.hóaĐƠnToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.hóaĐƠnToolStripMenuItem.Text = "Hóa đơn";

            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";

            this.khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            this.khoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.khoToolStripMenuItem.Text = "Kho";
            this.khoToolStripMenuItem.Click += new System.EventHandler(this.khoToolStripMenuItem_Click);

            this.báoCaoToolStripMenuItem.Name = "báoCaoToolStripMenuItem";
            this.báoCaoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.báoCaoToolStripMenuItem.Text = "Báo cáo";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.lblWelcome.Location = new System.Drawing.Point(50, 80);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 37);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Quản lý Bán hàng Di Động Việt";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainDashboard";
            this.Text = "Di Động Việt - Quản lý bán hàng";
            this.Load += new System.EventHandler(this.frmMainDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kinh DoanhtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐƠnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCaoToolStripMenuItem;
        private System.Windows.Forms.Label lblWelcome;
    }
}
