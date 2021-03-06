using System.Collections.Generic;

namespace PromotionEngine.Logic.Interfaces
{
    public interface IPromotion
    {
        float ApplyPromotion(Dictionary<Product, int> products);
    }
}