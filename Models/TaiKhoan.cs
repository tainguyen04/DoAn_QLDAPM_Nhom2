namespace QLCHBanDienThoaiMoi.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public VaiTro VaiTro { get; set; }
        public TrangThaiTaiKhoan TrangThai { get; set; } = TrangThaiTaiKhoan.Active;
        public NhanVien? NhanVien { get; set; }
        public KhachHang? KhachHang { get; set; }
    }
    public enum VaiTro
    {
        Admin,User 
        
    }
    public enum TrangThaiTaiKhoan
    {
        Active,Locked
    }
}
