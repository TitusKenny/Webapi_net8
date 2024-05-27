using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoHangController : ControllerBase
    {
        private List<KhoHang> khoHangs;
        private readonly MyDbContext _context;

        public async Task<IActionResult> Create(AddKhoHangVM kho)
        {
            try
            {
                var AddKhoHH = new KhoHang
                {
                    MaKhoHang = kho.MaKhoHang,
                    MaHangHoa = kho.MaHangHoa,
                    NgayNhapKho = kho.NgayNhapKho,

                };
                _context.Add(AddKhoHH);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, AddKhoHH);
            }
            catch
            {
                return BadRequest();
            }

        }
    } 
}
