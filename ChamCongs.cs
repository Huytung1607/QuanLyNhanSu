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
    public partial class ChamCongs : Form
    {
        public ChamCongs()
        {
            InitializeComponent();
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
                string sql = "select MaChamCong, TenTaiKhoan, MaBoPhan, Ngay, GioVao, GioRa from ChamCong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_ChamCong.DataSource = dt;
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

        private void btn_Back_Click(object sender, EventArgs e)
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
                string them = "INSERT INTO ChamCong VALUES (@MaChamCong, @TenTaiKhoan, @MaBoPhan,@Ngay,@GioVao,@GioRa)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaChamCong", txt_MaChamCong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                cmd.Parameters.AddWithValue("@GioVao", txt_GioVao.Text);
                cmd.Parameters.AddWithValue("@GioRa", txt_GioRa.Text);

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
                string sua = "UPDATE ChamCong SET TenTaiKhoan = @TenTaiKhoan, MaBoPhan = @MaBoPhan, Ngay = @Ngay, GioVao = @GioVao, GioRa = @GioRa WHERE MaChamCong = @MaChamCong";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaChamCong", txt_MaChamCong.Text);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TenTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtp_Ngay.Text);
                cmd.Parameters.AddWithValue("@GioVao", txt_GioVao.Text);
                cmd.Parameters.AddWithValue("@GioRa", txt_GioRa.Text);
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
                    string xoa = "DELETE FROM ChamCong WHERE TenTaiKhoan = @TenTaiKhoan";
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
            string timkiem = "select * from ChamCong WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_ChamCong.DataSource = dt;
        }

        private void grid_ChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_ChamCong.Rows[e.RowIndex];
            string macc = row.Cells[0].Value.ToString();
            string tentk = row.Cells[1].Value.ToString();
            string mabp = row.Cells[2].Value.ToString();
            dtp_Ngay.Value = Convert.ToDateTime(row.Cells[3].Value);
            string giovao = row.Cells[4].Value.ToString();
            string giora = row.Cells[5].Value.ToString();
            txt_MaChamCong.Text = macc;
            txt_TenTaiKhoan.Text = tentk;
            txt_MaBoPhan.Text = mabp;
            txt_GioVao.Text = giovao;
            txt_GioRa.Text = giora;
        }
    }
}
