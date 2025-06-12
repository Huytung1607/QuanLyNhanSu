using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class TaiKhoan : Form
    {
        QuanLyNhanSuEntities quanLyNhanSu = new QuanLyNhanSuEntities();
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
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
                string sql = "select TenTaiKhoan, MatKhau  from Login";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_TaiKhoan.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //them
        private void button1_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string them = "insert into Login values (@TenTaiKhoan,@MatKhau)";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TK.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txt_Mk.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Sua
        private void button2_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string sua = "UPDATE Login SET MatKhau = @MatKhau WHERE TenTaiKhoan = @TenTaiKhoan";
                SqlCommand cmd = new SqlCommand(sua, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TK.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txt_Mk.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //tim
        private void button4_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select * from Login WHERE TenTaiKhoan like @TenTaiKhoan";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@TenTaiKhoan", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_TaiKhoan.DataSource = dt;
        }
        //Xoa
        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi();
            try
            {
                string Xoa = "Delete from Login WHERE TenTaiKhoan = @TenTaiKhoan";
                SqlCommand cmd = new SqlCommand(Xoa, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", txt_TK.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công", "Thông báo");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu a = new Menu();
            a.Show();
        }

        private void grid_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_TaiKhoan.Rows[e.RowIndex];
            string ten = row.Cells[0].Value.ToString();
            string mk = row.Cells[1].Value.ToString();
            txt_TK.Text = ten;
            txt_Mk.Text = mk;
        }
    }
}
