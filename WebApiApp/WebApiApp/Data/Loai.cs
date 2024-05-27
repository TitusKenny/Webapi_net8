using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WebApiApp.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string? TenLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string? NhomLoai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
