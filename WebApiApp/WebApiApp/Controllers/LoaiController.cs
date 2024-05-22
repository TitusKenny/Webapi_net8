using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Data;
using WebApiApp.Models;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository;

        public LoaiController(ILoaiRepository loaiRepository) 
        {
            _loaiRepository = loaiRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            try
            {
                var data = _loaiRepository.GetbyID(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiVM loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }
            try
            {
               _loaiRepository.Update(loai);
               return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiRepository.Add(loai));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
