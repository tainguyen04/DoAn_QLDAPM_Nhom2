namespace QLCHBanDienThoaiMoi.Models
{
    public class DanhMucSanPham
    {
        public int Id { get; set; }
        public string? TenDanhMuc { get; set; }
        public ICollection<SanPham> SanPham { get; set; }
    }
}
