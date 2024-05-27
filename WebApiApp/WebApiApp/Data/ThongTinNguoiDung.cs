using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiApp.Data
{
    [Table("ThongTinNguoiDung")]
    public class ThongTinNguoiDung
    {
        [Key]
        public Guid TTId { get; set; }
        public string? HoTen {get;set;}
        public int Tuoi {get; set;}
        public string? DiaChi { get; set;}
        public string? GioiTinh { get; set; }
        public int SoDT { get;set;}
        public string? Email { get; set; }
        public DateTime NamSinh { get;set;}
        public int? MaChucVu { get; set; }
        [ForeignKey("MaChucVu")]
        public ChucVu? ChucVu { get; set; }
    }
}
