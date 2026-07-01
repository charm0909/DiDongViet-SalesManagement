using System;
using System.Windows.Forms;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmMainDashboard : Form
    {
        public frmMainDashboard()
        {
            InitializeComponent();
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmProduct());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmEmployee());
        }

        private void kháchhàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCustomer());
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmSupplier());
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmWarehouse());
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }
    }
}
