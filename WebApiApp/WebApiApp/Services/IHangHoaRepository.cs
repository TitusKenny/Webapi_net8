using System.Globalization;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string Search, double? from, double? to, string sortBy, int page = 1);
    }
}
