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
    public partial class BaoHiems : Form
    {
        public BaoHiems()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_DC_TextChanged(object sender, EventArgs e)
        {

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
                string sql = "select * from BaoHiem";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_BaoHiem.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BaoHiems_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_BaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_BaoHiem.Rows[e.RowIndex];
            string mabh = row.Cells[0].Value.ToString();
            string tentk = row.Cells[1].Value.ToString();
            string mabp = row.Cells[2].Value.ToString();
            string loaibh = row.Cells[3].Value.ToString();
            string sohieu = row.Cells[4].Value.ToString();
            dtp_NgayCap.Value = Convert.ToDateTime(row.Cells[5].Value);
            dtp_NgayHetHan.Value = Convert.ToDateTime(row.Cells[6].Value);
            string ghichu = row.Cells[7].Value.ToString();
            txt_MaBH.Text = mabh;
            txt_TenTaiKhoan.Text = tentk;
            txt_MaBoPhan.Text = mabp;
            txt_LoaiBaoHiem.Text = loaibh;
            txt_SoHieu.Text = sohieu;
            txtGhiChu.Text = ghichu;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO BaoHiem VALUES (@MaBaoHiem, @TenTaiKhoan, @MaBoPhan,@LoaiBaoHiem,@SoHieuBH,@NgayCap,@NgayHetHan,@GhiChu)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaBaoHiem", txt_MaBH.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LoaiBaoHiem", txt_LoaiBaoHiem.Text);
                cmd.Parameters.AddWithValue("@SoHieuBH", txt_SoHieu.Text);
                cmd.Parameters.AddWithValue("@NgayCap", dtp_NgayCap.Text);
                cmd.Parameters.AddWithValue("@NgayHetHan", dtp_NgayHetHan.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

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
                string sua = "UPDATE BaoHiem SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, LoaiBaoHiem = @LoaiBaoHiem, SoHieuBH = @SoHieuBH, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan WHERE MaBaoHiem = @MaBaoHiem";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaBaoHiem", txt_MaBH.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LoaiBaoHiem", txt_LoaiBaoHiem.Text);
                cmd.Parameters.AddWithValue("@SoHieuBH", txt_SoHieu.Text);
                cmd.Parameters.AddWithValue("@NgayCap", dtp_NgayCap.Text);
                cmd.Parameters.AddWithValue("@NgayHetHan", dtp_NgayHetHan.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
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
                    string xoa = "DELETE FROM BaoHiem WHERE TenTaiKhoan = @TenTaiKhoan";
                    SqlCommand cmd = new SqlCommand(xoa, conn);
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
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
            string timkiem = "select * from BaoHiem WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_BaoHiem.DataSource = dt;
        }
    }
}
