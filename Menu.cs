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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class Menu : Form
    {
        QuanLyNhanSuEntities quanLyNhanSu = new QuanLyNhanSuEntities();
        public Menu()
        {
            InitializeComponent();
        }


        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhenThuongs b = new KhenThuongs();
            b.Show();
        }

        private void btn_Dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap form = new DangNhap();
            form.Show();
            form.Refresh();
        }
        SqlConnection conn;
        void ketnoi()
        {
            try
            {
                string connect = @"Data Source=DESKTOP-TN1V66D\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
                conn = new SqlConnection(connect);
                SqlCommand cmd = new SqlCommand(connect,conn);
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
                string sql = "select TenTaiKHoan, MaBoPhan, HoTen , NgaySinh, GioiTinh , DiaChi,SoDienThoai , Email  from HoSoNhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grid_NhanVien.DataSource = dt;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            ketnoi();
            string timkiem = "select TenTaiKHoan, MaBoPhan ,HoTen , NgaySinh, GioiTinh , DiaChi,SoDienThoai , Email  from HoSoNhanVien  WHERE HoTen like @HoTen";
            SqlCommand cmd = new SqlCommand(timkiem, conn);
            cmd.Parameters.AddWithValue("@HoTen", "%" + txt_Timkiem.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            grid_NhanVien.DataSource = dt;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            lblTieuDe.Text = "Xin chào : " + User.tenNguoiDung;
            grid_NhanVien.RowHeadersVisible = false;
            lblNgay.Text = "Ngày : " + DateTime.Now.ToString("dd/MM/yyyy");
            ketnoi();
            loadData();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            grid_NhanVien.RowHeadersVisible = false;
            ketnoi();
            loadData();
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaiKhoan a = new TaiKhoan();
            a.Show();
        }

        private void grid_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChucVu a = new ChucVu();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiMatKhaus b = new DoiMatKhaus();
            b.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BoPhans c = new BoPhans();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChamCongs d = new ChamCongs();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LuongNhanViens d = new LuongNhanViens();
            d.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            TinhLuongs d = new TinhLuongs();
            d.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            HopDongs d = new HopDongs();
            d.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoSoNhanViens d = new HoSoNhanViens();
            d.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoHiems d = new BaoHiems();
            d.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            KyLuats d = new KyLuats();
            d.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThaiSans d = new ThaiSans();
            d.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVienDiTres d = new NhanVienDiTres();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LamThemGios d = new LamThemGios();
            d.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThamNienNhanViens d = new ThamNienNhanViens();
            d.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
