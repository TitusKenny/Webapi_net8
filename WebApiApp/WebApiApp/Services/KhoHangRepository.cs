using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface IKhoHangRepository
    {
        List<KhoHangVM> GetAll();
        KhoHangVM GetbyID(string id);
        KhoHangVM Add(KhoHangVM kho);
        void Update(string id, KhoHangVM kho);
        void Delete(string id);

    }

    public class KhoHangRepository : IKhoHangRepository
    {
        private readonly MyDbContext _context;
        public KhoHangVM Add(KhoHangVM kho)
        {
            var _kho = new KhoHang
            {
                TenKhoHang = kho.TenKhoHang
            };
            _context.Add(_kho);
            _context.SaveChanges();

            return new KhoHangVM
            {
                MaKhoHang = Guid.NewGuid(),
                TenKhoHang = _kho.TenKhoHang
            };
        }

        public void Delete(string id)
        {
            var _khos = _context.KhoHangs.SingleOrDefault(kh => kh.MaKhoHang == Guid.Parse(id));
            if (_khos != null)
            {
                _context.Remove(_khos);
                _context.SaveChanges();
            }
        }

        public List<KhoHangVM> GetAll()
        {
            var khos = _context.KhoHangs.Select(kh => new KhoHangVM
            {
                TenKhoHang = kh.TenKhoHang
            });
            return khos.ToList();
        }

        public KhoHangVM GetbyID(string id)
        {
            var khos = _context.KhoHangs.SingleOrDefault(kh => kh.MaKhoHang == Guid.Parse(id));
            if (khos != null)
            {
                return new KhoHangVM
                {
                    TenKhoHang = khos.TenKhoHang
                };
            }
            return null;
        }

        public void Update(string id, KhoHangVM kho)
        {
            var _khos = _context.KhoHangs.SingleOrDefault(kh => kh.MaKhoHang == Guid.Parse(id));
            if (_khos != null)
            {
                kho.TenKhoHang = _khos.TenKhoHang;
            }
            _context.SaveChanges();
        }
    }
}
