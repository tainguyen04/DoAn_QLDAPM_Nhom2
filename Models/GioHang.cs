using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class GioHang
    {
        public int? KhachHangId { get; set; }
        public KhachHang KhachHang { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public ICollection<GioHang> GioHangs { get; set; } // Thêm navigation property ngược
        public ICollection<HoaDonBan> HoaDonBans { get; set; }

        [NotMapped]
        public int ThanhTien => SoLuong *  SanPham.GiaBan;
    }
}
