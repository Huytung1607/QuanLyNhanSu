using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu
{
    internal class DangNhapDAL
    {
        public bool CheckLogin(string username, string password)
        {
            using (QuanLyNhanSuEntities context = new QuanLyNhanSuEntities())
            {
                return context.Logins
                    .Any(user => user.TenTaiKhoan == username && user.MatKhau == password);
            }
        }
    }
}
