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
    public partial class BoPhans : Form
    {
        public BoPhans()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
        }
        QuanLyNhanSuEntities a = new QuanLyNhanSuEntities();
        SqlConnection conn;

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoi();
                string them = "insert into BoPhan values (@MaBoPhan,@TenBoPhan)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@TenBoPhan", txt_TenBoPhan.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ketnoi()
        {
            try
            {
                string connect = "Data Source=DESKTOP-TN1V66D\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
                conn = new SqlConnection(connect);
                SqlCommand cmd = new SqlCommand(connect,conn);
                conn.Open();
            }catch(Exception e) 
            {
                MessageBox.Show(e.Message);

            }
        }
        void loadData()
        {
            ketnoi();
            try
            {
                string sql = "select MaBoPhan , TenBoPhan from BoPhan";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_BoPhan.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid_BoPhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BoPhans_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_BoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_BoPhan.Rows[e.RowIndex];
            string ma = row.Cells[0].Value.ToString();
            string ten = row.Cells[1].Value.ToString();
            txt_MaBoPhan.Text = ma;
            txt_TenBoPhan.Text = ten;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sua = "UPDATE BoPhan SET TenBoPhan = @TenBoPhan WHERE MaBoPhan = @MaBoPhan";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
                cmd.Parameters.AddWithValue("@TenBoPhan", txt_TenBoPhan.Text);
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
                    string xoa = "DELETE FROM BoPhan WHERE MaBoPhan = @MaBoPhan";
                    SqlCommand cmd = new SqlCommand(xoa, conn);
                    cmd.Parameters.AddWithValue("@MaBoPhan", txt_MaBoPhan.Text);
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
            string timkiem = "select * from BoPhan WHERE TenBoPhan like @TenBoPhan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenBoPhan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_BoPhan.DataSource = dt;
        }
    }
}
