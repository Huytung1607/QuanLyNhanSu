//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhanSu
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhenThuong
    {
        public string MaKhenThuong { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MaBoPhan { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayKT { get; set; }
    
        public virtual BoPhan BoPhan { get; set; }
        public virtual Login Login { get; set; }
    }
}
