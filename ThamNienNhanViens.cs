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
    public partial class ThamNienNhanViens : Form
    {
        public ThamNienNhanViens()
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
                string sql = "SELECT TenTaiKhoan, MaBoPhan, NgayVaoLam FROM ThamNienNhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("SoNamLamViec", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    if (DateTime.TryParse(row["NgayVaoLam"].ToString(), out DateTime ngayVaoLam))
                    {
                        TimeSpan duration = DateTime.Now - ngayVaoLam;
                        DateTime zeroTime = new DateTime(1, 1, 1);
                        DateTime span = zeroTime + duration;

                        int years = span.Year - 1;
                        int months = span.Month - 1;
                        int days = span.Day - 1;

                        row["SoNamLamViec"] = $"{years} năm {months} tháng {days} ngày";
                    }
                    else
                    {
                        row["SoNamLamViec"] = "Không xác định";
                    }
                }

                grid_ThamNien.DataSource = dt;
                grid_ThamNien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void ThamNienNhanViens_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_ThamNien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_ThamNien.Rows[e.RowIndex];

            txt_TenTaiKhoan.Text = row.Cells[0].Value?.ToString();
            txt_MaBoPhan.Text = row.Cells[1].Value?.ToString();

            if (DateTime.TryParse(row.Cells[2].Value?.ToString(), out DateTime ngayVaoLam))
            {
                dtp_NgayVaoLam.Value = ngayVaoLam;
                int soNam = (int)((DateTime.Now - ngayVaoLam).TotalDays / 365);
                txt_SoNam.Text = soNam.ToString();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "INSERT INTO ThamNienNhanVien VALUES (@TenTaiKhoan, @MaBoPhan,@NgayVaoLam,@SoNamLamViec)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@NgayVaoLam", dtp_NgayVaoLam.Text);
                cmd.Parameters.AddWithValue("@SoNamLamViec", txt_SoNam.Text);
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
                string sua = "UPDATE ThamNienNhanVien SET MaBoPhan = @MaBoPhan, NgayVaoLam = @NgayVaoLam, SoNamLamViec = @SoNamLamViec WHERE TenTaiKhoan = @TenTaiKhoan";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@NgayVaoLam", dtp_NgayVaoLam.Text);
                cmd.Parameters.AddWithValue("@SoNamLamViec", txt_SoNam.Text);
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
                    string xoa = "DELETE FROM ThamNienNhanVien WHERE TenTaiKhoan = @TenTaiKhoan";
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
            string timkiem = "select * from ThamNienNhanVien WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_ThamNien.DataSource = dt;
        }
    }
}
