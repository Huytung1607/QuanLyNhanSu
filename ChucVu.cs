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
    public partial class ChucVu : Form
    {
        QuanLyNhanSuEntities quanLyNhanSu = new QuanLyNhanSuEntities();
        public ChucVu()
        {
            InitializeComponent();
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
                string sql = "select TenDangNhap, TenHienThi , LoaiNhanVien  from DangKy";
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
        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                // Kiểm tra xem TenDangNhap có tồn tại trong Login chưa
                string kiemTraLogin = "SELECT COUNT(*) FROM Login WHERE TenTaiKhoan = @TenDangNhap";
                SqlCommand checkCmd = new SqlCommand(kiemTraLogin, conn);
                checkCmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    MessageBox.Show("Tên đăng nhập chưa tồn tại trong bảng Login. Vui lòng thêm tài khoản vào bảng Login trước.");
                    return;
                }

                string them = "INSERT INTO DangKy VALUES (@TenDangNhap, @TenHienThi, @LoaiNhanVien)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text);
                cmd.Parameters.AddWithValue("@TenHienThi", txt_TenHienThi.Text);
                cmd.Parameters.AddWithValue("@LoaiNhanVien", cb_loaiNV.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DangKys_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
        }

        private void grid_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_TaiKhoan.Rows[e.RowIndex];
            string tendn = row.Cells[0].Value.ToString();
            string tenht = row.Cells[1].Value.ToString();
            string loainv = row.Cells[2].Value.ToString();
            txt_TenDangNhap.Text = tendn;
            txt_TenHienThi.Text = tenht;
            cb_loaiNV.Text = loainv;

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select * from DangKy WHERE TenHienThi like @TenHienThi";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenHienThi", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_TaiKhoan.DataSource = dt;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sua = "UPDATE DangKy SET TenHienThi = @TenHienThi, LoaiNhanVien = @LoaiNhanVien WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text);
                cmd.Parameters.AddWithValue("@TenHienThi", txt_TenHienThi.Text);
                cmd.Parameters.AddWithValue("@LoaiNhanVien", cb_loaiNV.SelectedItem.ToString());
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
                    string xoa = "DELETE FROM DangKy WHERE TenHienThi = @TenHienThi";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
