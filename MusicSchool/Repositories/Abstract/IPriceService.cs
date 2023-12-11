using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;

namespace MusicSchool.Repositories.Abstract
{
    public interface IPriceService
    {
        public List<PriceModel> GetAllPrices();

        public Task SetPrices(SetPricesModel model);

        public Task UpdatePrices(SetPricesModel model);

        public ClassModel GetCurrentClass(int Id);

        public PriceModel GetCurrentPrice(int Id);
    }
}
