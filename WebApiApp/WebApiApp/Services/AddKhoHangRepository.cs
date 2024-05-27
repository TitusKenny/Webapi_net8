using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface IAddKhoHangRepository
    {
        List<AddKhoHangVM> GetAll();
        AddKhoHangVM GetbyID(string id);
        Task<bool> Add(string khoid,string hhid, AddKhoHangVM kho);
        void Update(string id, AddKhoHangVM kho);
        void Delete(string id);

    }
    public class AddKhoHangRepository : IAddKhoHangRepository
    {
        private readonly MyDbContext _context;

        public async Task<bool> Add(string khoid, string hhid, AddKhoHangVM kho)
        {
            var kh = _context.KhoHangs.FirstOrDefault(kh => kh.MaKhoHang == Guid.Parse(khoid));
            if (kh != null)
            {
                //check tồn tại kho hàng
                var addhh = _context.KhoHangs.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(hhid));
                if (addhh == null)
                {
                    var chkhh = _context.HangHoas.FirstOrDefault(chkhh => chkhh.MaHh == Guid.Parse(hhid));
                    if (chkhh != null)
                    {
                        var kho_add = new AddKhoHangVM();
                        kho_add.MaKhoHang = kh.MaKhoHang;
                        kho_add.MaHangHoa = addhh.MaHangHoa;
                        kho_add.MaLoai = chkhh.MaLoai;
                        kho_add.NgayNhapKho = DateTime.Now;
                        kho_add.SoLuongXuatKho = kho_add.SoLuongXuatKho;
                        kho_add.SoLuongNhapKho = kho.SoLuongNhapKho;
                        kho_add.SoLuongTonKho = kho_add.SoLuongTonKho + kho_add.SoLuongNhapKho;

                        //await _context.KhoHangs.AddAsync(kho_add);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
            }
            return false;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<AddKhoHangVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public AddKhoHangVM GetbyID(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, AddKhoHangVM kho)
        {
            throw new NotImplementedException();
        }
    }
}
