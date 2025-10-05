
using InventoryPartMastery.Models;

namespace InventoryPartMastery.Services
{
    public class StockPredictionService
    {
        public string PredictRisk(Part part)
        {
            if (part.StockQuantity < 10)
                return "High Risk";
            else if (part.StockQuantity < 30)
                return "Medium Risk";
            else
                return "Safe";
        }
    }
}
