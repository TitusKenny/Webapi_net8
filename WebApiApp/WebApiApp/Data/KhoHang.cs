using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApp.Data
{
    [Table("MaKhoHang")]
    public class KhoHang
    {
        [Key]
        public Guid MaKhoHang {  get; set; }
        public String? TenKhoHang { get; set; }
        public Guid MaHangHoa { get; set; }
        [ForeignKey("MaHangHoa")]
        public ICollection<HangHoa> HangHoas { get; set; }
        public int SoLuongTonKho {  get; set; }
        public int SoLuongXuatKho { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public int MaLoai {  get; set; }
        [ForeignKey("MaLoai")]
        public ICollection<Loai> Loais { get; set;}
    }
}
