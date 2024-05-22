using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(hangHoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            { 
                //LINQ [Object] query
                var HangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (HangHoa == null )
                {
                    return NotFound();
                }
                return Ok(HangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM) 
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia

            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                success = true,
                data = hanghoa
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id,HangHoa hangHoaEdit)
        {   
            try
            {
                var HangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                if (id != HangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //update
                HangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                HangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok(HangHoa);
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Remove(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var HangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                //Delete
                hangHoas.Remove(HangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
