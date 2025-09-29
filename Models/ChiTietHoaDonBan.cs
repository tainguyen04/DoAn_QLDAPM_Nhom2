

namespace QLCHBanDienThoaiMoi.Models
{
    public class ChiTietHoaDonBan
    {
        public int Id { get;set; }
        public int HoaDonBanId { get;set; }
        public HoaDonBan HoaDonBan { get;set; }
        public int SanPhamId { get;set; }
        public SanPham SanPham { get;set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public int PhieuBaoHanhId { get; set; }
        public PhieuBaoHanh PhieuBaoHanh { get; set; }
    }
}
