using Microsoft.EntityFrameworkCore;
using MusicSchool.Models.Domain;
using MusicSchool.Models.DTO;
using MusicSchool.Repositories.Abstract;

namespace MusicSchool.Repositories.Implementation
{
    public class PriceService : IPriceService
    {
        private readonly DatabaseContext databaseContext;

        public PriceService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<PriceModel> GetAllPrices()
        {
            return databaseContext.Prices.ToList();
        }

        public ClassModel GetCurrentClass(int Id)
        {
            return databaseContext.Classes.FirstOrDefault(c => c.Id == Id);
        }

        public PriceModel GetCurrentPrice(int Id)
        {
            return databaseContext.Prices.FirstOrDefault(c => c.Id == Id);
        }

        public async Task SetPrices(SetPricesModel model)
        {
            var @class = await databaseContext.Classes.FirstOrDefaultAsync(c => c.ClassName == model.ClassName);
            PriceModel priceModel = new()
            {
                Price = model.Price,
                ClassId = @class.Id
            };

            databaseContext.Prices.Add(priceModel);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdatePrices(SetPricesModel model)
        {
            var price = await databaseContext.Prices.FirstOrDefaultAsync(p => p.Id == model.Id);

            price.Price = model.Price;
            
            databaseContext.Prices.Update(price);
            await databaseContext.SaveChangesAsync();
        }
    }
}
