using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class DangNhap : Form
    {
        QuanLyNhanSuEntities a = new QuanLyNhanSuEntities();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Pass.UseSystemPasswordChar = false;
            }
            else
            {
                txt_Pass.UseSystemPasswordChar = true;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_User.Text.Trim();
            string password = txt_Pass.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Cảnh báo");
                return;
            }

            DangNhapDAL dangnhap = new DangNhapDAL();
            if (dangnhap.CheckLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                this.Hide();
                Loading formLoading = new Loading();
                formLoading.Show();
                formLoading.Refresh();
                System.Threading.Thread.Sleep(2000);
                formLoading.Close();
                Menu formTrangChu = new Menu();
                User.tenNguoiDung = username;
                formTrangChu.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi");
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_User.Text = "";
            txt_Pass.Text = "";
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình .", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txt_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Pass.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Login.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_Reset_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
