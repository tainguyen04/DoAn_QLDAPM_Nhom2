using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class HoaDonBan
    {
        public int Id { get; set; }
        public DateTime NgayBan { get; set; }
        public int KhanhHangId { get; set; }
        public KhachHang KhachHang { get;set; }
        public int? NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
        public ICollection<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }
        [NotMapped]
        public decimal ThanhTien => ChiTietHoaDonBan.Sum(ct => ct.GiaBan * (1 - ct.KhuyenMai / 100) * ct.SoLuong);
    }
}
