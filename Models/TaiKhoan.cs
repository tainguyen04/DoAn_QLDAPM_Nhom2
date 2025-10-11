namespace QLCHBanDienThoaiMoi.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public VaiTro VaiTro { get; set; }
        public TrangThai TrangThai { get; set; }
        public NhanVien? NhanVien { get; set; }
        public KhachHang? KhachHang { get; set; }
    }
    public enum VaiTro
    {
        Admin,User 
        
    }
    public enum TrangThai
    {
        Active,Locked
    }
}
