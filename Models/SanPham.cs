namespace QLCHBanDienThoaiMoi.Models
{
    public class SanPham
    {
        
        public int Id { get;set; }
        public string TenSanPham { get; set; } = null!;
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int DanhMucId { get; set; }
        
        public string HangSanXuat { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public string? HinhAnh { get; set; }
        public decimal KhuyenMai { get; set; } = 0;
        public DanhMucSanPham? DanhMucSanPham { get; set; }
        public ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; } = new List<ChiTietHoaDonNhap>();
        public ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; } = new List<ChiTietHoaDonBan>();
        public ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();
    }
}
