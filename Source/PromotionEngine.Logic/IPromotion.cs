using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public interface IPromotion
    {
        float ApplyPromotion(Dictionary<Product, int> products);
    }
}