using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public interface IPromotion
    {
        float ApplyPromotion(List<Product> products);
    }
}