//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tmdt_th_newsweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BinhLuan
    {
        public string MaBL { get; set; }
        public string MaBV { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
    
        public virtual BaiViet BaiViet { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
