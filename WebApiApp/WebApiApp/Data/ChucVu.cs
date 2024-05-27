using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace WebApiApp.Data
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public Guid MaChucVu { get; set; }
        public string? TenChucVu { get; set; }
    }
}
