using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _HangHoaRepository;

        public ProductsController(IHangHoaRepository hangHoaRepository) 
        {
            _HangHoaRepository = hangHoaRepository;
        }
        [HttpGet]
        public IActionResult GetAllProduct(string search, double? from, double? to, string sortBy, int page = 1) 
        {
            try
            {
                var result = _HangHoaRepository.GetAll(search, from,to, sortBy);
                return Ok(result);
            }
            catch 
            {
                return BadRequest("We can't get the product.");
            }
        }

    }
}
