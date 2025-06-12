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
    public partial class HopDongs : Form
    {
        public HopDongs()
        {
            InitializeComponent();
        }
        QuanLyNhanSuEntities quanLy  = new QuanLyNhanSuEntities();
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
            try
            {
                ketnoi();
                string sql = " select * from HopDong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_HopDong.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);   
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void HopDongs_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_HopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_HopDong.Rows[e.RowIndex];
            string mahd = row.Cells[0].Value.ToString();
            string tentk = row.Cells[1].Value.ToString();
            string mabp = row.Cells[2].Value.ToString();
            string loaihd = row.Cells[3].Value.ToString();
            dtp_NgayBD.Value = Convert.ToDateTime(row.Cells[4].Value);
            dtp_NgayKT.Value = Convert.ToDateTime(row.Cells[5].Value);
            txt_MaHD.Text = mahd;
            txt_TenTaiKhoan.Text = tentk;
            txt_MaBoPhan.Text = mabp;
            txt_Loai.Text = loaihd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO HopDong VALUES (@MaHopDong, @TenTaiKhoan, @MaBoPhan,@LoaiHopDong,@NgayBatDau,@NgayKetThuc)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaHopDong", txt_MaHD.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LoaiHopDong", txt_Loai.Text);
                cmd.Parameters.AddWithValue("@NgayBatDau", dtp_NgayBD.Text);
                cmd.Parameters.AddWithValue("@NgayKetThuc", dtp_NgayKT.Text);

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
                string sua = "UPDATE HopDong SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, LoaiHopDong = @LoaiHopDong, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc WHERE MaHopDong = @MaHopDong";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaHopDong", txt_MaHD.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@LoaiHopDong", txt_Loai.Text);
                cmd.Parameters.AddWithValue("@NgayBatDau", dtp_NgayBD.Text);
                cmd.Parameters.AddWithValue("@NgayKetThuc", dtp_NgayKT.Text);
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
                    string xoa = "DELETE FROM HopDong WHERE TenTaiKhoan = @TenTaiKhoan";
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
            string timkiem = "select * from HopDong WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_HopDong.DataSource = dt;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {

        }
    }
}
