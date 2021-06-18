using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public interface ICart
    {
        void AddProduct(Product product, int quantity);
        void ClearCart();
        void ClearPromotions();
        void ApplyPromotions(List<IPromotion> promotions);
        void Checkout();
    }
}