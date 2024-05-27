using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WebApiApp.Data
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key] 
        public Guid MaNguoiDung { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Password { get; set; }
        public int MaQuyen { get; set; }
        public Guid TTId { get; set; }
        [ForeignKey("TTId")]
        public ThongTinNguoiDung? ThongTinNguoiDung { get; set; }
        public Guid TonTai{get;set;}
    }
}
