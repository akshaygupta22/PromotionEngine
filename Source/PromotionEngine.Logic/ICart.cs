using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public interface ICart
    {
        void AddProduct(Product product);
        void ClearCart();
        void ClearPromotions();
        void ApplyPromotions(List<Promotion> promotions);
        void Checkout();
    }
}