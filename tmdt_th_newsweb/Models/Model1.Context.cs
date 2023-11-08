﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TMDT_TH_newsWebEntities : DbContext
    {
        public TMDT_TH_newsWebEntities()
            : base("name=TMDT_TH_newsWebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<GoiDichVu> GoiDichVus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiKH> LoaiKHs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
    
        public virtual int sp_ChinhSuaBV(string idbv, string tieude, string noidung, Nullable<System.DateTime> ngaysua)
        {
            var idbvParameter = idbv != null ?
                new ObjectParameter("idbv", idbv) :
                new ObjectParameter("idbv", typeof(string));
    
            var tieudeParameter = tieude != null ?
                new ObjectParameter("tieude", tieude) :
                new ObjectParameter("tieude", typeof(string));
    
            var noidungParameter = noidung != null ?
                new ObjectParameter("noidung", noidung) :
                new ObjectParameter("noidung", typeof(string));
    
            var ngaysuaParameter = ngaysua.HasValue ?
                new ObjectParameter("ngaysua", ngaysua) :
                new ObjectParameter("ngaysua", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ChinhSuaBV", idbvParameter, tieudeParameter, noidungParameter, ngaysuaParameter);
        }
    
        public virtual int sp_ThemBV(string tieude, string noidung, Nullable<System.DateTime> ngaydang, Nullable<System.DateTime> ngaysua, Nullable<int> trangthai, string manv, string makh)
        {
            var tieudeParameter = tieude != null ?
                new ObjectParameter("tieude", tieude) :
                new ObjectParameter("tieude", typeof(string));
    
            var noidungParameter = noidung != null ?
                new ObjectParameter("noidung", noidung) :
                new ObjectParameter("noidung", typeof(string));
    
            var ngaydangParameter = ngaydang.HasValue ?
                new ObjectParameter("ngaydang", ngaydang) :
                new ObjectParameter("ngaydang", typeof(System.DateTime));
    
            var ngaysuaParameter = ngaysua.HasValue ?
                new ObjectParameter("ngaysua", ngaysua) :
                new ObjectParameter("ngaysua", typeof(System.DateTime));
    
            var trangthaiParameter = trangthai.HasValue ?
                new ObjectParameter("trangthai", trangthai) :
                new ObjectParameter("trangthai", typeof(int));
    
            var manvParameter = manv != null ?
                new ObjectParameter("manv", manv) :
                new ObjectParameter("manv", typeof(string));
    
            var makhParameter = makh != null ?
                new ObjectParameter("makh", makh) :
                new ObjectParameter("makh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemBV", tieudeParameter, noidungParameter, ngaydangParameter, ngaysuaParameter, trangthaiParameter, manvParameter, makhParameter);
        }
    
        public virtual int sp_XoaBV(string idbv)
        {
            var idbvParameter = idbv != null ?
                new ObjectParameter("idbv", idbv) :
                new ObjectParameter("idbv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaBV", idbvParameter);
        }
    
        public virtual int sp_LockTT(string idbv, Nullable<int> trangthai)
        {
            var idbvParameter = idbv != null ?
                new ObjectParameter("idbv", idbv) :
                new ObjectParameter("idbv", typeof(string));
    
            var trangthaiParameter = trangthai.HasValue ?
                new ObjectParameter("trangthai", trangthai) :
                new ObjectParameter("trangthai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_LockTT", idbvParameter, trangthaiParameter);
        }
    
        public virtual int sp_ChinhSuaNV(string maNV, string tenNV, string diaChi, string email, string sDT, string userName, string password, string maCV, string hinhAnh)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var maCVParameter = maCV != null ?
                new ObjectParameter("MaCV", maCV) :
                new ObjectParameter("MaCV", typeof(string));
    
            var hinhAnhParameter = hinhAnh != null ?
                new ObjectParameter("HinhAnh", hinhAnh) :
                new ObjectParameter("HinhAnh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ChinhSuaNV", maNVParameter, tenNVParameter, diaChiParameter, emailParameter, sDTParameter, userNameParameter, passwordParameter, maCVParameter, hinhAnhParameter);
        }
    
        public virtual int sp_ThemNV(string tenNV, string diaChi, string email, string sDT, string userName, string maCV, string hinhAnh)
        {
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var maCVParameter = maCV != null ?
                new ObjectParameter("MaCV", maCV) :
                new ObjectParameter("MaCV", typeof(string));
    
            var hinhAnhParameter = hinhAnh != null ?
                new ObjectParameter("HinhAnh", hinhAnh) :
                new ObjectParameter("HinhAnh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemNV", tenNVParameter, diaChiParameter, emailParameter, sDTParameter, userNameParameter, maCVParameter, hinhAnhParameter);
        }
    
        public virtual int sp_XoaNV(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaNV", maNVParameter);
        }
    
        public virtual int sp_XetDuyetLaiTT(string idbv)
        {
            var idbvParameter = idbv != null ?
                new ObjectParameter("idbv", idbv) :
                new ObjectParameter("idbv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XetDuyetLaiTT", idbvParameter);
        }
    }
}
