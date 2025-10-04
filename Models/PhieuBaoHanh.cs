namespace QLCHBanDienThoaiMoi.Models
{
    public class PhieuBaoHanh
    {
        public int Id { get; set; }
        
        public int ChiTietHoaDonBanId { get; set; } 
        public ChiTietHoaDonBan ChiTietHoaDonBan { get; set; }

        public DateTime NgayLap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string MoTa { get;set; }
        public string TrangThai { get; set; } = "DangBaoHanh";

    }
}
