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
        
        [NotMapped]
        public int ThanhTien => SoLuong *  SanPham.GiaBan;
    }
}
