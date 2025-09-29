using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class ChiTietHoaDonNhap
    {
        [Key]
        [Column(Order = 1)]
        public int HoaDonNhapId {get;set; }
        [Key]
        [Column(Order = 2)]
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        public HoaDonNhap HoaDonNhap { get; set; }
        public SanPham SanPham { get; set; }

    }
}
