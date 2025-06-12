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
    public partial class TinhLuongs : Form
    {
        public TinhLuongs()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu d = new Menu();
            d.Show();
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
                string sql = "select MaTinhLuong, TenTaiKhoan, MaBoPhan, TuNgay, DenNgay, TongLuong ,NgayTinh from TinhLuong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_TinhLuong.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TinhLuongs_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_TinhLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_TinhLuong.Rows[e.RowIndex];

                txt_MaTinhLuong.Text = row.Cells["MaTinhLuong"].Value?.ToString();
                txt_TenTaiKhoan.Text = row.Cells["TenTaiKhoan"].Value?.ToString();
                txt_MaBoPhan.Text = row.Cells["MaBoPhan"].Value?.ToString();
                dtp_TuNgay.Value = Convert.ToDateTime(row.Cells["TuNgay"].Value);
                dtp_DenNgay.Value = Convert.ToDateTime(row.Cells["DenNgay"].Value);
                txt_TongLuong.Text = row.Cells["TongLuong"].Value?.ToString();
                dtp_NgayTinh.Value = Convert.ToDateTime(row.Cells["NgayTinh"].Value);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sql = "INSERT INTO TinhLuong VALUES (@MaTinhLuong, @TenTaiKhoan, @MaBoPhan, @TuNgay, @DenNgay, @TongLuong, @NgayTinh)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTinhLuong", txt_MaTinhLuong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@TuNgay", dtp_TuNgay.Value);
                cmd.Parameters.AddWithValue("@DenNgay", dtp_DenNgay.Value);
                cmd.Parameters.AddWithValue("@TongLuong", decimal.Parse(txt_TongLuong.Text));
                cmd.Parameters.AddWithValue("@NgayTinh", dtp_NgayTinh.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!", "Thông báo");
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
                string sql = "UPDATE TinhLuong SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, TuNgay = @TuNgay, DenNgay = @DenNgay, TongLuong = @TongLuong, NgayTinh = @NgayTinh WHERE MaTinhLuong = @MaTinhLuong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTinhLuong", txt_MaTinhLuong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@TuNgay", dtp_TuNgay.Value);
                cmd.Parameters.AddWithValue("@DenNgay", dtp_DenNgay.Value);
                cmd.Parameters.AddWithValue("@TongLuong", decimal.Parse(txt_TongLuong.Text));
                cmd.Parameters.AddWithValue("@NgayTinh", dtp_NgayTinh.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "Thông báo");
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
                string sql = "DELETE FROM TinhLuong WHERE MaTinhLuong = @MaTinhLuong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTinhLuong", txt_MaTinhLuong.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select * from TinhLuong WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_TinhLuong.DataSource = dt;
        }
    }
}
