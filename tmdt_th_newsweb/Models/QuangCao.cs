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
    
    public partial class QuangCao
    {
        public string MaQC { get; set; }
        public string TenQC { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string HinhAnh { get; set; }
        public string MaNV { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
