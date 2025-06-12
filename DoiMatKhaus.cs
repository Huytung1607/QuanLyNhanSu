using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanSu
{
    public partial class DoiMatKhaus : Form
    {
        QuanLyNhanSuEntities quanLyNhanSu = new QuanLyNhanSuEntities();

        public DoiMatKhaus()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn;
        void ketnoi()
        {
            try
            {
                string connect = @"Data Source=DESKTOP-TN1V66D\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
                conn = new SqlConnection(connect);
                SqlCommand cmd = new SqlCommand(connect, conn);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadData()
        {
            ketnoi();
            try
            {
                string sql = "select TenDangNhap, TenHienThi , MatKhauCu,MatKhauMoi,NhapLaiMatKhau  from DoiMatKhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_TaiKhoan.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoiMatKhaus_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO DoiMatKhau VALUES (@TenDangNhap, @TenHienThi, @MatKhauCu,@MatKhauMoi,@NhapLaiMatKhau)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text);
                cmd.Parameters.AddWithValue("@TenHienThi", txt_TenHienThi.Text);
                cmd.Parameters.AddWithValue("@MatKhauCu", txt_MkCu.Text);
                cmd.Parameters.AddWithValue("@MatKhauMoi", txt_MkMoi.Text);
                cmd.Parameters.AddWithValue("@NhapLaiMatKhau", txt_NhaplaiMK.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sua = "UPDATE DoiMatKhau SET TenHienThi = @TenHienThi, MatKhauCu = @MatKhauCu,MatKhauMoi = @MatKhauMoi,NhapLaiMatKhau = @NhapLaiMatKhau WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text);
                cmd.Parameters.AddWithValue("@TenHienThi", txt_TenHienThi.Text);
                cmd.Parameters.AddWithValue("@MatKhauCu", txt_MkCu.Text);
                cmd.Parameters.AddWithValue("@MatKhauMoi", txt_MkMoi.Text);
                cmd.Parameters.AddWithValue("@NhapLaiMatKhau", txt_NhaplaiMK.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string xoa = "DELETE FROM DoiMatKhau WHERE TenHienThi = @TenHienThi";
                    SqlCommand cmd = new SqlCommand(xoa, conn);
                    cmd.Parameters.AddWithValue("@TenHienThi", txt_TenDangNhap.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công", "Thông báo");
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select * from DoiMatKhau WHERE TenHienThi like @TenHienThi";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenHienThi", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_TaiKhoan.DataSource = dt;
        }

        private void grid_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_TaiKhoan.Rows[e.RowIndex];
            string tendn = row.Cells[0].Value.ToString();
            string tenht = row.Cells[1].Value.ToString();
            string mkcu = row.Cells[2].Value.ToString();
            string mkmoi = row.Cells[3].Value.ToString();
            string nhaplaiMK = row.Cells[4].Value.ToString();
            txt_TenDangNhap.Text = tendn;
            txt_TenHienThi.Text = tenht;
            txt_MkCu.Text = mkcu;
            txt_MkMoi.Text = mkmoi;
            txt_NhaplaiMK.Text = nhaplaiMK;
        }
    }
}
