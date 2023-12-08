using MusicSchool.Models.Domain;

namespace MusicSchool.Repositories.Abstract
{
    public interface IPriceService
    {
        public List<PriceModel> GetAllPrices();

        public Task SetPrices();

        public Task UpdatePrices(ExtraClassModel extraClasse);

        public Task DeletePrices(ExtraClassModel extraClass);
    }
}
