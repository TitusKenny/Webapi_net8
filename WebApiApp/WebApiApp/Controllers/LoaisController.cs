﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaisController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("id")]
        public IActionResult GetById(int id) 
        {
            var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id) ;
            if (loai != null)
                return Ok(loai);
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(LoaiModel model)
        { 
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("id")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model) 
        {
            var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
