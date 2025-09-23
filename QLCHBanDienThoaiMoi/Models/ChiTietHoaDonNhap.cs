namespace QLCHBanDienThoaiMoi.Models
{
    public class ChiTietHoaDonNhap
    {
        public int HoaDonNhapId {get;set; }
        public HoaDonNhap HoaDonNhap { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        
    }
}
