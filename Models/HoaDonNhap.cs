using System.ComponentModel.DataAnnotations.Schema;

namespace QLCHBanDienThoaiMoi.Models
{
    public class HoaDonNhap
    {
        public int Id { get;set; }
        public DateTime NgayLap { get; set; }
        public int NCCId { get; set; }
        public NhaCungCap NhaCungCap { get; set; } = null!;
        public ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; } = new List<ChiTietHoaDonNhap>();
        [NotMapped]
        public decimal ThanhTien => ChiTietHoaDonNhaps.Sum(ct => ct.GiaNhap * ct.SoLuong);
    }
}
