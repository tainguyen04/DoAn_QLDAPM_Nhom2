

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class ChiTietHoaDonBan
    {
        [Key]
        [Column(Order = 1)]
        public int HoaDonBanId { get;set; }
        
        [Key]
        [Column(Order = 2)]
        public int SanPhamId { get;set; }
        
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        
        public PhieuBaoHanh? PhieuBaoHanh { get; set; }
        public HoaDonBan? HoaDonBan { get; set; } 
        public SanPham? SanPham { get; set; }
    }
}
