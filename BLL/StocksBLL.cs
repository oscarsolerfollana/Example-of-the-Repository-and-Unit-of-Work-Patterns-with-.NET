using DowJones.DAL;
using System.Linq;

namespace DowJones.BLL
{
    public class StocksBLL
    {
        private readonly UnitOfWork unitOfWork;
        public StocksBLL(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public float? GetStockPrice(int stockId)
        {
            return unitOfWork.StocksRepository.Get(i => i.Id == stockId).FirstOrDefault()?.Price;
        }

        public void SetStockPrice(int stockId, float price)
        {
            var stock = unitOfWork.StocksRepository.Get(i => i.Id == stockId).FirstOrDefault();
            if (stock == null) return;
            stock.Price = price;
            unitOfWork.StocksRepository.Update(stock);
            unitOfWork.Save();
        }
    }
}
