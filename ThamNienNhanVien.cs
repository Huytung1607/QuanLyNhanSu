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
    
    public partial class ThamNienNhanVien
    {
        public string TenTaiKhoan { get; set; }
        public string MaBoPhan { get; set; }
        public System.DateTime NgayVaoLam { get; set; }
        public Nullable<int> SoNamLamViec { get; set; }
    
        public virtual BoPhan BoPhan { get; set; }
        public virtual Login Login { get; set; }
    }
}
