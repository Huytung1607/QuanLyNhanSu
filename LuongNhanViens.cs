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
    public partial class LuongNhanViens : Form
    {
        public LuongNhanViens()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
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
                string sql = "select MaLuong, TenTaiKhoan, MaBoPhan, LuongCoBan, PhuCap, NgayCapNhat from LuongNhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_LuongNV.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LuongNhanViens_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_BoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_LuongNV.Rows[e.RowIndex];
            string maluong = row.Cells[0].Value.ToString();
            string tentk = row.Cells[1].Value.ToString();
            string mabp = row.Cells[2].Value.ToString();
            string luongcoban = row.Cells[3].Value.ToString();
            string phucap = row.Cells[4].Value.ToString();
            dtp_Ngay.Value = Convert.ToDateTime(row.Cells[5].Value);
            txt_MaLuong.Text = maluong;
            txt_TenTaiKhoan.Text = tentk;
            txt_MaBoPhan.Text = mabp;
            txt_LuongCoBan.Text = luongcoban;
            txt_PhuCap.Text = phucap;
        }

        private void grid_LuongNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select * from LuongNhanVien WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_LuongNV.DataSource = dt;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO LuongNhanVien VALUES (@MaLuong, @TenTaiKhoan, @MaBoPhan, @LuongCoBan, @PhuCap, @NgayCapNhat)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaLuong", txt_MaLuong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LuongCoBan", decimal.Parse(txt_LuongCoBan.Text));
                cmd.Parameters.AddWithValue("@PhuCap", decimal.Parse(txt_PhuCap.Text));
                cmd.Parameters.AddWithValue("@NgayCapNhat", dtp_Ngay.Value);

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
                string sua = "UPDATE LuongNhanVien SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, LuongCoBan = @LuongCoBan, PhuCap = @PhuCap, NgayCapNhat = @NgayCapNhat WHERE MaLuong = @MaLuong";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaLuong", txt_MaLuong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LuongCoBan", decimal.Parse(txt_LuongCoBan.Text));
                cmd.Parameters.AddWithValue("@PhuCap", decimal.Parse(txt_PhuCap.Text));
                cmd.Parameters.AddWithValue("@NgayCapNhat", dtp_Ngay.Value);

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
                string xoa = "DELETE FROM LuongNhanVien WHERE MaLuong = @MaLuong";
                SqlCommand cmd = new SqlCommand(xoa, conn);
                cmd.Parameters.AddWithValue("@MaLuong", txt_MaLuong.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
