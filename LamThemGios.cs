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
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace QuanLyNhanSu
{
    public partial class LamThemGios : Form
    {
        public LamThemGios()
        {
            InitializeComponent();
        }

        private void txt_Timkiem_TextChanged(object sender, EventArgs e)
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
                string sql = "select * from LamThemGio";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_Lamthem.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LamThemGios_Load(object sender, EventArgs e)
        {
            loadData();
            dtp_Gio.Format = DateTimePickerFormat.Custom;
            dtp_Gio.CustomFormat = "HH:mm";
            dtp_Gio.ShowUpDown = true;
        }

        private void grid_DiTre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grid_Lamthem.Rows.Count)
            {
                DataGridViewRow row = grid_Lamthem.Rows[e.RowIndex];

                txt_MaBC.Text = row.Cells[0].Value?.ToString();
                txt_TenTaiKhoan.Text = row.Cells[1].Value?.ToString();
                txt_MaBoPhan.Text = row.Cells[2].Value?.ToString();

                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngay))
                    dtp_Ngay.Value = ngay;

                if (decimal.TryParse(row.Cells[4].Value?.ToString(), out decimal sogio))
                {
                    int gio = (int)sogio;
                    int phut = (int)((sogio - gio) * 60);
                    dtp_Gio.Value = new DateTime(2000, 1, 1, gio, phut, 0); 
                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO LamThemGio VALUES (@MaLamThem, @TenTaiKhoan, @MaBoPhan,@Ngay,@SoGio)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaLamThem", txt_MaBC.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                TimeSpan gio = dtp_Gio.Value.TimeOfDay;
                decimal sogio = gio.Hours + gio.Minutes / 60.0m;
                cmd.Parameters.AddWithValue("@SoGio", sogio);


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
                string sua = "UPDATE LamThemGio SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, Ngay = @Ngay, SoGio = @SoGio WHERE MaLamThem = @MaLamThem";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaLamThem", txt_MaBC.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                TimeSpan gio = dtp_Gio.Value.TimeOfDay;
                decimal sogio = gio.Hours + gio.Minutes / 60.0m;
                cmd.Parameters.AddWithValue("@SoGio", sogio);

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
                    string xoa = "DELETE FROM LamThemGio WHERE TenTaiKhoan = @TenTaiKhoan";
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
            string timkiem = "select * from LamThemGio WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_Lamthem.DataSource = dt;
        }
    }
}
