namespace QLCHBanDienThoaiMoi.Models
{
    public class SanPham
    {
        
        public int Id { get;set; }
        public string TenSanPham { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int DanhMucId { get; set; }
        public DanhMucSanPham DanhMucSanPham { get; set; }
        public string HangSanXuat { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public decimal KhuyenMai { get; set; } = 0;
        public ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
    }
}
