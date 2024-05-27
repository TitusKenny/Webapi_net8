using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using WebApiApp.Data;

namespace WebApiApp.Models
{
    public class KhoHangVM
    {
        public Guid MaKhoHang { get; set; }
        public String? TenKhoHang { get; set; }
    }
    public class AddKhoHangVM
    {
        public Guid MaKhoHang { get; set; }
        public Guid MaHangHoa { get; set; }
        public int SoLuongTonKho { get; set; }
        public int SoLuongXuatKho { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public int? MaLoai { get; set; }
        public int SoLuongNhapKho { get; set; }
    }

}
