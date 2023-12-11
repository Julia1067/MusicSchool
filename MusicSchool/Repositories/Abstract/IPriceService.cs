using MusicSchool.Models.Domain;

namespace MusicSchool.Repositories.Abstract
{
    public interface IPriceService
    {
        public List<PriceModel> GetAllPrices();

        public Task SetPrices();

        public Task UpdatePrices(ClassModel extraClasse);

        public Task DeletePrices(ClassModel extraClass);
    }
}
