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
    public partial class NhanVienDiTres : Form
    {
        public NhanVienDiTres()
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
                string sql = "select * from NhanVienDiTre";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_DiTre.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NhanVienDiTres_Load(object sender, EventArgs e)
        {
            loadData();
            dtp_Gio.Format = DateTimePickerFormat.Custom;
            dtp_Gio.CustomFormat = "HH:mm:ss";
            dtp_Gio.ShowUpDown = true;

        }

        private void grid_DiTre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                DataGridViewRow row = grid_DiTre.Rows[e.RowIndex];
                txt_MaBC.Text = row.Cells[0].Value?.ToString();
                txt_TenTaiKhoan.Text = row.Cells[1].Value?.ToString();
                txt_MaBoPhan.Text = row.Cells[2].Value?.ToString();
                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngay))
                    dtp_Ngay.Value = ngay;
                if (TimeSpan.TryParse(row.Cells[4].Value?.ToString(), out TimeSpan gioVao))
                    dtp_Gio.Value = DateTime.Today.Date + gioVao;
        }
        private void grid_DiTre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO NhanVienDiTre VALUES (@MaBaoCao, @TenTaiKhoan, @MaBoPhan,@Ngay,@GioVao)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaBaoCao", txt_MaBC.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                cmd.Parameters.AddWithValue("@GioVao", dtp_Gio.Text);

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
                string sua = "UPDATE NhanVienDiTre SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, Ngay = @Ngay, GioVao = @GioVao WHERE MaBaoCao = @MaBaoCao";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaBaoCao", txt_MaBC.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                cmd.Parameters.AddWithValue("@GioVao", dtp_Gio.Text);
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
                    string xoa = "DELETE FROM NhanVienDiTre WHERE TenTaiKhoan = @TenTaiKhoan";
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
            string timkiem = "select * from NhanVienDiTre WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_DiTre.DataSource = dt;
        }
    }
}
