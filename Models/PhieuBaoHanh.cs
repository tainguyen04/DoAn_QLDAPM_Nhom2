using System.ComponentModel.DataAnnotations;

namespace QLCHBanDienThoaiMoi.Models
{
    public class PhieuBaoHanh
    {
        public int Id { get; set; }

        public int HoaDonBanId { get; set; }
        public int SanPhamId { get; set; }

        public DateTime NgayLap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string? MoTa { get; set; }
        public TrangThaiBaoHanh TrangThai { get; set; } = TrangThaiBaoHanh.DangBaoHanh;
        
        public required ChiTietHoaDonBan ChiTietHoaDonBan { get; set; } 

    }
    public enum TrangThaiBaoHanh
    {
        DangBaoHanh,HetHan
    }
}
