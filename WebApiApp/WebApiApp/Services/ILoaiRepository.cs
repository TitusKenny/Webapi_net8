using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetbyID(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);

    }
}
