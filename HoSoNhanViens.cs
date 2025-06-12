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
    public partial class HoSoNhanViens : Form
    {
        public HoSoNhanViens()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_Loai_TextChanged(object sender, EventArgs e)
        {

        }
        QuanLyNhanSuEntities quanLyNhanSu = new QuanLyNhanSuEntities();
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
                string sql = "select * from HoSoNhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_HoSoNV.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ChamCongs_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void HoSoNhanViens_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu d = new Menu();
            d.Show();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO HoSoNhanVien VALUES (@MaHoSo, @TenTaiKhoan, @MaBoPhan,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@SoDienThoai,@Email)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaHoSo", txt_MaHS.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@HoTen", txt_Hoten.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbo_Gioitinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txt_DC.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txt_SDT.Text);
                cmd.Parameters.AddWithValue("@Email", txt_Email.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid_HoSoNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_HoSoNV.Rows[e.RowIndex];
            string mahs = row.Cells[0].Value.ToString();
            string tentk = row.Cells[1].Value.ToString();
            string mabp = row.Cells[2].Value.ToString();
            string hoten = row.Cells[3].Value.ToString();
            dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells[4].Value);
            string gt = row.Cells[5].Value.ToString();
            string dc = row.Cells[6].Value.ToString();
            string sdt = row.Cells[7].Value.ToString();
            string email = row.Cells[8].Value.ToString();
            txt_MaHS.Text = mahs;
            txt_TenTaiKhoan.Text = tentk;
            txt_MaBoPhan.Text = mabp;
            txt_Hoten.Text = hoten;
            cbo_Gioitinh.Text = gt;
            txt_DC.Text = dc;
            txt_SDT.Text = sdt;
            txt_Email.Text = email;

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sua = "UPDATE HoSoNhanVien SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai ,Email = @Email WHERE MaHoSo = @MaHoSo";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaHoSo", txt_MaHS.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@HoTen", txt_Hoten.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbo_Gioitinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txt_DC.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txt_SDT.Text);
                cmd.Parameters.AddWithValue("@Email", txt_Email.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
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
                    string xoa = "DELETE FROM HoSoNhanVien WHERE HoTen = @HoTen";
                    SqlCommand cmd = new SqlCommand(xoa, conn);
                    cmd.Parameters.AddWithValue("@HoTen", txt_Hoten.Text);
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
            string timkiem = "select * from HoSoNhanVien WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_HoSoNV.DataSource = dt;
        }
    }
}
