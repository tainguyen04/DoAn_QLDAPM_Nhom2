namespace QLCHBanDienThoaiMoi.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public VaiTro VaiTro { get; set; }
        public NhanVien NhanVien { get; set; }
        public KhachHang KhachHang { get; set; }
    }
    public enum VaiTro
    {
        Admin = 1,
        User = 0
        
    }
}
