using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class HoaDonBan
    {
        public int Id { get; set; }
        public DateTime NgayBan { get; set; }
        public int KhachHangId { get; set; }
        public KhachHang KhachHang { get;set; }
        public int? NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
        public ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        [NotMapped]
        public decimal ThanhTien => ChiTietHoaDonBans.Sum(ct => ct.GiaBan * (1 - ct.SanPham.KhuyenMai / 100) * ct.SoLuong);
    }
}
