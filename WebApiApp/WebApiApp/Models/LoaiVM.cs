using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models
{
    public class LoaiVM
    {
        public int MaLoai { get; set; }    
        public string? TenLoai { get; set; }
        public string? NhomLoai { get; set; }
    }
}
