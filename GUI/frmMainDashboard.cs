using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.DTO;

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
            this.Text = "Dashboard - Di Động Việt";
            this.WindowState = FormWindowState.Maximized;
            lblWelcome.Text = $"Xin chào, {GlobalData.CurrentUser.HoTen}!";
            lblRole.Text = $"Quyền: {GlobalData.CurrentUser.LoaiTK}";
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Hiển thị thống kê
            lblTotalProducts.Text = "250 sản phẩm";
            lblInventory.Text = "1,500 chiếc";
            lblTodayRevenue.Text = "25,500,000 đ";
            lblTodayInvoices.Text = "15 hóa đơn";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.ShowDialog();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng bán hàng", "Thông báo");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng nhập hàng", "Thông báo");
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quản lý kho", "Thông báo");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng báo cáo", "Thông báo");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GlobalData.CurrentUser = null;
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void frmMainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
